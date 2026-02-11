using Microsoft.IdentityModel.JsonWebTokens;
using Sample.Cqrs.Application.Abstractions.Security;

namespace Sample.Cqrs.Api.Middlewares
{
    public class TokenBlacklistMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenBlacklistMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            ITokenBlacklist blacklist)
        {
            var jti = context.User?
                .FindFirst(JwtRegisteredClaimNames.Jti)?.Value;

            if (!string.IsNullOrEmpty(jti) &&
                await blacklist.IsBlacklistedAsync(jti))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token has been revoked.");
                return;
            }

            await _next(context);
        }
    }
}
