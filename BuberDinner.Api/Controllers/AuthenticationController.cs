using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contacts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controller
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            var auResult = _authenticationService.Register(request.LastName,
                                            request.FirstName,
                                            request.Email,
                                            request.Password);
            var response = new AuthenticationRespone(auResult.FirstName,
                                                    auResult.LastName,
                                                    auResult.Email,
                                                    auResult.Token,
                                                    auResult.Id);
            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var auResult = _authenticationService.Login(request.Email,
                                                        request.Password);

            var response = new AuthenticationRespone(auResult.FirstName,
                                                    auResult.LastName,
                                                    auResult.Email,
                                                    auResult.Token,
                                                    auResult.Id);
            return Ok(response);
        }
    }
}
