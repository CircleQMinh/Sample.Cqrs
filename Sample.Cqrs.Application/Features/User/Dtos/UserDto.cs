using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.User.Dtos
{
    public class UserDto
    {
        public int Id { get; init; }
        public string Email { get; init; } = default!;
        public string Role { get; init; } = default!;
    }
}
