using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Sample.Cqrs.Application.Abstractions.Repositories;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Sample.Cqrs.Domain.Entities;

namespace Sample.Cqrs.Application.Features.User.Login
{
    public class LoginHandler
           : IRequestHandler<LoginRequest, BaseResponse<string>>
    {
        private readonly IGenericRepository<Entities.User> _users;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtTokenGenerator _jwt;

        public LoginHandler(
            IGenericRepository<Entities.User> users,
            IPasswordHasher hasher,
            IJwtTokenGenerator jwt)
        {
            _users = users;
            _hasher = hasher;
            _jwt = jwt;
        }

        public async Task<BaseResponse<string>> Handle(
            LoginRequest request,
            CancellationToken cancellationToken)
        {
            var user = await _users.Get(
                u => u.Email == request.Email);

            if (user == null || !_hasher.Verify(user.PasswordHash, request.Password))
            {
                //return BaseResponse<string>.Failure(
                //    new[] { "Invalid username or password." });

                var errors = new List<ValidationFailure>
                {
                    new ValidationFailure("Email","Invalid username or password." )
                };
                throw new ValidationException("Invalid username or password.", errors);
            }

            var token = _jwt.GenerateToken(user);

            return new BaseResponse<string>
            {
                Success = true,
                Result = token,
                Message = "Login successful"
            };
        }
    }

}
