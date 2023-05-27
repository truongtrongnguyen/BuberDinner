﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GeneratorToken(Guid userId, string firstName, string LastName);
    }
}