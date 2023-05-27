using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication
{
    public record AuthenticationResult(string FirstName,
                                        string LastName,
                                        string Email,
                                        string Token,
                                        Guid Id);
}
