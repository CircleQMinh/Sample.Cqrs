using Sample.Cqrs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.Command.Dtos
{
    public class CommandDto
    {
        public int Id { get; set; } = 0;

        public string HowTo { get; set; } = string.Empty;
        public string CommandLine { get; set; } = string.Empty;

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }


}
