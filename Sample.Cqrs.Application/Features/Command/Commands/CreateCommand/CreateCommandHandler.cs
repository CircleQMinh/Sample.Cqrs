using MediatR;
using Sample.Cqrs.Application.Abstractions;
using Sample.Cqrs.Application.Features.Command.Dtos;
using Sample.Cqrs.Domain.Common;
using Sample.Cqrs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Sample.Cqrs.Domain.Entities;
namespace Sample.Cqrs.Application.Features.Command.Commands.CreateCommand
{
    public class CreateCommandHandler : IRequestHandler<CreateCommandRequest, BaseResponse<CommandDto>>
    {
        private readonly IGenericRepository<Entities.Command> _repository;
        public CreateCommandHandler(IGenericRepository<Entities.Command> repository)
        {
            _repository = repository;
            // should add mapper
        }
        public async Task<BaseResponse<CommandDto>> Handle(CreateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = new Entities.Command
                {
                    CommandLine = request.CommandLine,
                    HowTo = request.HowTo,
                    PlatformId = request.PlatformId,
                };
                await _repository.Insert(command);
                await _repository.SaveChangesAsync();
                return new BaseResponse<CommandDto>
                {
                    Success = true,
                    Result = new CommandDto
                    {
                        CommandLine = command.CommandLine,
                        HowTo = command.HowTo,
                        Id = command.Id,
                        PlatformId = command.PlatformId,
                    }
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<CommandDto>
                {
                    Errors = new List<string> { e.Message },
                    Message = e.Message,
                    Success = false,
                };
            }
        }
    }
}
