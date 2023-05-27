using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Register(string firstName, string password, string email, string lastName)
        {
            return new AuthenticationResult(firstName,
                                            email,
                                            lastName,
                                            "token",
                                            Guid.NewGuid());
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
