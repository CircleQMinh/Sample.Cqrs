using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.Command.Commands.CreateCommand
{
    public class CreateCommandValidator : AbstractValidator<CreateCommandRequest>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.HowTo).NotEmpty();
            RuleFor(x => x.CommandLine).NotEmpty();
            RuleFor(x => x.PlatformId).GreaterThan(0);
        }
    }
}
