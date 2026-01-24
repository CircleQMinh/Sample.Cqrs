using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Domain.Entities
{
    public class Platform
    {
        [Key]
        public int Id { get; set; } = 0;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string LicenseKey { get; set; } = string.Empty;
        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
