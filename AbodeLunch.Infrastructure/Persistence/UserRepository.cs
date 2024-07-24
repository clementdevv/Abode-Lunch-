using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbodeLunch.Application.Common.Interfaces.Persistence;
using AbodeLunch.Domain.Entities;

namespace AbodeLunch.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}