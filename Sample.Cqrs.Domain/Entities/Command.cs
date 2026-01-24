using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Domain.Entities
{
    public class Command
    {
        [Key]
        public int Id { get; set; } = 0;
        [Required]

        public string HowTo { get; set; } = string.Empty;
        [Required]
        public string CommandLine { get; set; } = string.Empty;

        [Required]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
