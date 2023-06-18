using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Contacts.Authentication
{
    public record class AuthenticationRespone(Guid Id,
                                            string FirstName,
                                            string LastName,
                                            string Email,
                                            string Token);
}
