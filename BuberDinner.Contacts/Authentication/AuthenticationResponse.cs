
using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Contacts.Authentication
{
    public record class AuthenticationRespone(User user,
                                            string Token);
}
