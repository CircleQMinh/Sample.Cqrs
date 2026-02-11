using Microsoft.Extensions.Options;
using Sample.Cqrs.Domain.Entities;
using Sample.Cqrs.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sample.Cqrs.Tests.Sample.Infrastructure.Tests.Security
{
    public class JwtTokenGeneratorTest
    {
        private readonly JwtTokenGenerator _sut;
        private readonly JwtSettings _settings;

        public JwtTokenGeneratorTest()
        {
            _settings = new JwtSettings
            {
                Key = "THIS_IS_A_SUPER_SECRET_KEY_123456789", 
                Issuer = "TestIssuer",
                Audience = "TestAudience",
                ExpiryMinutes = 60
            };

            var options = Options.Create(_settings);

            _sut = new JwtTokenGenerator(options);
        }

        [Fact]
        public void GenerateToken_CorrectInput_ShouldReturn_Valid_Jwt()
        {
            // Arrange
            var user = new User
            {
                Id = 10,
                Username = "testuser",
                Role = "Admin"
            };

            // Act
            var tokenString = _sut.GenerateToken(user);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(tokenString));

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(tokenString);

            Assert.Equal(_settings.Issuer, token.Issuer);
            Assert.Contains(_settings.Audience, token.Audiences);

        }
    }
}
