using BuberDinner.Api.Controllers;
using BuberDinner.Contacts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Application.Services.Authentication.Common;
using MediatR;
using BuberDinner.Application.Services.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;

namespace BuberDinner.Api.Controller
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        // IMediatR inheritance ISender
        private readonly ISender _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

            return registerResult.Match(
                registerResult => Ok(MapAuthResult(registerResult)),
                errors => Problem(errors));
        }

        private static AuthenticationRespone MapAuthResult(AuthenticationResult auResult)
        {
            return new AuthenticationRespone(auResult.user,
                                             auResult.Token);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);

            var auResult = await _mediator.Send(query);

            if (auResult.IsError && auResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: auResult.FirstError.Description);
            }

            return auResult.Match(
                auResult => Ok(MapAuthResult(auResult)),
                errors => Problem(errors));

        }
    }
}
