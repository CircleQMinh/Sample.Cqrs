using Microsoft.AspNetCore.Identity;
using Sample.Cqrs.Application.Abstractions.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Infrastructure.Security
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string Hash(string password)
            => _hasher.HashPassword(new object(), password);

        public bool Verify(string hash, string password)
            => _hasher.VerifyHashedPassword(new object(), hash, password)
               == PasswordVerificationResult.Success;
    }
}
