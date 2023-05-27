using BuberDinner.Api.Controllers;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contacts.Authentication;
using ErrorOr;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Domain.Common.Errors;

namespace BuberDinner.Api.Controller
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
                request.LastName,
                request.FirstName,
                request.Email,
                request.Password);

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
        public IActionResult Login(LoginRequest request)
        {
            var auResult = _authenticationService.Login(request.Email,
                                                        request.Password);
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
