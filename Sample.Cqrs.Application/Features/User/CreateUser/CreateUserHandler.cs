using FluentValidation;
using FluentValidation.Results;
using MediatR;
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

namespace Sample.Cqrs.Application.Features.User.CreateUser
{
    public sealed class CreateUserHandler
          : IRequestHandler<CreateUserRequest, BaseResponse<UserDto>>
    {
        private readonly IGenericRepository<Entities.User> _users;
        private readonly IPasswordHasher _hasher;

        public CreateUserHandler(
            IGenericRepository<Entities.User> users,
            IPasswordHasher hasher)
        {
            _users = users;
            _hasher = hasher;
        }

        public async Task<BaseResponse<UserDto>> Handle(
            CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            var existingUser = await _users.Get(
                u => u.Email == request.Email);

            if (existingUser != null)
            {
                var errors = new List<ValidationFailure>
                {
                    new ValidationFailure("Email","Email already registered." )
                };
                throw new ValidationException("Email already registered.", errors);
                //return BaseResponse<UserDto>.Failure(
                //    new[] { "Email already registered." });
            }

            var user = new Entities.User
            {
                Username = request.Email,
                Email = request.Email,
                PasswordHash = _hasher.Hash(request.Password),
                Role = "User",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "system"
            };

            await _users.Insert(user);
            await _users.SaveChangesAsync();

            return new BaseResponse<UserDto>
            {
                Success = true,
                Message = "User created successfully.",
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
