using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbodeLunch.Domain.Entities;

namespace AbodeLunch.Application.Common.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}