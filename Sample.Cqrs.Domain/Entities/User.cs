using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; } 
        public string PasswordHash { get; set; } 
        public string Role { get; set; } = "User";

        public User Update()
        {
            //check email format ...

            return this;
        }
    }
}
