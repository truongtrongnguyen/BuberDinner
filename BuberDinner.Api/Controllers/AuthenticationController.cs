using BuberDinner.Api.Controllers;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contacts.Authentication;
using ErrorOr;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Application.Services.Authentication.Command;
using BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Application.Services.Authentication.Common;

namespace BuberDinner.Api.Controller
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationCommandService,
                                        IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationCommandService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(
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
            var auResult = _authenticationQueryService.Login(request.Email,
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
