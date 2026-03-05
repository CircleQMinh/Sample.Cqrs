using MediatR;
using Sample.Cqrs.Application.Features.User.Dtos;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.User.GetCurrentUser
{
    public record GetCurrentUserRequest() : IRequest<BaseResponse<UserDto>>;
}
