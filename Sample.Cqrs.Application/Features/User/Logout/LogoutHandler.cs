using MediatR;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.User.Logout
{
    public class LogoutHandler
        : IRequestHandler<LogoutRequest, BaseResponse<string>>
    {
        private readonly IUserContext _user;
        private readonly ITokenBlacklist _blacklist;

        public LogoutHandler(
            IUserContext user,
            ITokenBlacklist blacklist)
        {
            _user = user;
            _blacklist = blacklist;
        }

        public async Task<BaseResponse<string>> Handle(
            LogoutRequest request,
            CancellationToken cancellationToken)
        {
            await _blacklist.BlacklistAsync(
                _user.Jti,
                _user.ExpiresAt);

            return new BaseResponse<string>
            {
                Success = true,
                Result = "Logged out successfully.",
            };
        }
    }

}
