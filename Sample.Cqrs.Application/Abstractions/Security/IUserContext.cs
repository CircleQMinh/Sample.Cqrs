using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Abstractions.Security
{
    public interface IUserContext
    {
        int UserId { get; }
        string Email { get; }
        string Jti { get; }
        DateTime ExpiresAt { get; }
    }
}
