
using Sample.Cqrs.Application.Abstractions.Mediator;
using Sample.Cqrs.Application.Abstractions.Repositories;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Application.Features.User.Dtos;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Sample.Cqrs.Domain.Entities;
namespace Sample.Cqrs.Application.Features.User.GetCurrentUser
{
    public class GetCurrentUserHandler
        : IRequestHandler<GetCurrentUserRequest, BaseResponse<UserDto>>
    {
        private readonly IUserContext _context;
        private readonly IGenericRepository<Entities.User> _users;

        public GetCurrentUserHandler(
            IUserContext context,
            IGenericRepository<Entities.User> users)
        {
            _context = context;
            _users = users;
        }

        public async Task<BaseResponse<UserDto>> Handle(
            GetCurrentUserRequest request,
            CancellationToken ct)
        {
            var user = await _users.Get(q => q.Id == _context.UserId);

            return new BaseResponse<UserDto>
            {
                Success = true,
                Result = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role
                }
            };
        }
    }

}
