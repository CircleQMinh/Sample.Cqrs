using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Infrastructure.Security
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _http;

        public UserContext(IHttpContextAccessor http)
        {
            _http = http;
        }

        public int UserId =>
            int.Parse(_http.HttpContext!
                .User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        public string Email =>
            _http.HttpContext!
                .User.FindFirst(ClaimTypes.Name)!.Value;
        public string Jti =>
        _http.HttpContext!
                .User.FindFirst(JwtRegisteredClaimNames.Jti)!.Value;

        public DateTime ExpiresAt =>
            DateTimeOffset.FromUnixTimeSeconds(
                long.Parse(_http.HttpContext!
                .User.FindFirst(JwtRegisteredClaimNames.Exp)!.Value))
            .UtcDateTime;
    }

}