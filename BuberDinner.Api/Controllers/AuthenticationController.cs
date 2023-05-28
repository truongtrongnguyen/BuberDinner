using BuberDinner.Api.Controllers;
using BuberDinner.Contacts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Application.Services.Authentication.Common;
using MediatR;
using BuberDinner.Application.Services.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace BuberDinner.Api.Controller
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        // IMediatR inheritance ISender
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

            return registerResult.Match(
                registerResult => Ok(_mapper.Map<AuthenticationRespone>(registerResult)),
                errors => Problem(errors));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var auResult = await _mediator.Send(query);

            if (auResult.IsError && auResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: auResult.FirstError.Description);
            }

            return auResult.Match(
                auResult => Ok(_mapper.Map<AuthenticationResult>(auResult)),
                errors => Problem(errors));

        }
    }
}
