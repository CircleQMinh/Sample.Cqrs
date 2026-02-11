using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Abstractions.Security
{
    public interface ITokenBlacklist
    {
        Task BlacklistAsync(string jti, DateTime expiresAt);
        Task<bool> IsBlacklistedAsync(string jti);
    }
}
