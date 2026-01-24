using MediatR;
using Sample.Cqrs.Application.Features.Command.Dtos;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.Command.Commands.CreateCommand
{
    public sealed record CreateCommandRequest(
        string HowTo,
        string CommandLine,
        int PlatformId
    ) : IRequest<BaseResponse<CommandDto>>;

}
