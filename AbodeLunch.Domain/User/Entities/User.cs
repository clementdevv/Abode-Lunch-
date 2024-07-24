using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbodeLunch.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } =string.Empty;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        
                
    }
}