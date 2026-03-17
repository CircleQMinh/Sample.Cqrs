using Microsoft.Extensions.Caching.Memory;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Infrastructure.Security
{
    public class MemoryTokenBlacklist : ITokenBlacklist
    {
        private readonly IMemoryCache _cache;

        public MemoryTokenBlacklist(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task BlacklistAsync(string jti, DateTime expiresAt)
        {
            var ttl = expiresAt - DateTime.UtcNow;

            if (ttl <= TimeSpan.Zero)
                return Task.CompletedTask;

            _cache.Set(jti, true, ttl);

            return Task.CompletedTask;
        }

        public Task<bool> IsBlacklistedAsync(string jti)
        {
            return Task.FromResult(
                _cache.TryGetValue(jti, out _));
        }
    }
}

