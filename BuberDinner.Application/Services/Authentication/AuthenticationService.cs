using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // check if user already exists

            // create user (generate unique ID)

            // create Jwt Token
            Guid userId = Guid.NewGuid();

            var token = _jwtTokenGenerator.GeneratorToken(userId, firstName, lastName);

            return new AuthenticationResult(firstName,
                                            lastName,
                                            email,
                                            token,
                                            userId);
        }

        public AuthenticationResult Login(string password, string email)
        {
            return new AuthenticationResult("firstName",
                                            email,
                                            "lastName",
                                            "token",
                                            Guid.NewGuid());
        }
    }
}
