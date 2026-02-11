using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Infrastructure.Security
{
    public class JwtSettings
    {
        public string Key { get; init; } = default!;
        public string Issuer { get; init; } = default!;
        public string Audience { get; init; } = default!;
        public int ExpiryMinutes { get; init; }
    }

}
