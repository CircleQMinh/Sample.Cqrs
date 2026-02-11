using Moq;
using Sample.Cqrs.Application.Abstractions.Repositories;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Application.Features.Product.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Entities = Sample.Cqrs.Domain.Entities;
namespace Sample.Cqrs.Tests.Sample.Application.Tests.Features.Product
{
    public class CreateProductHandlerTest
    {
        private readonly Mock<IGenericRepository<Entities.Product>> _repoMock;
        private readonly Mock<IUserContext> _userContextMock;
        private readonly CreateProductHandler _handler;

        public CreateProductHandlerTest()
        {
            _repoMock = new Mock<IGenericRepository<Entities.Product>>();
            _userContextMock = new Mock<IUserContext>();

            // Default setups (shared across tests)
            _repoMock
                .Setup(r => r.Insert(It.IsAny<Entities.Product>()))
                .Returns(Task.CompletedTask);

            _repoMock
                .Setup(r => r.SaveChangesAsync())
                .ReturnsAsync(true);

            _userContextMock.Setup(u => u.UserId).Returns(1);
            _userContextMock.Setup(u => u.Email).Returns("email@test.com");
            _userContextMock.Setup(u => u.Jti).Returns("123");
            _userContextMock.Setup(u => u.ExpiresAt).Returns(DateTime.UtcNow);

            _handler = new CreateProductHandler(
                _repoMock.Object,
                _userContextMock.Object);
        }

        [Fact]
        public async Task CreateProductHandler_CorrectInput_ShouldCreate()
        {
            // Arrange
            var request = new CreateProductRequest(
                "Test Product",
                "Description",
                "image.jpg",
                10,
                5);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);

            _repoMock.Verify(
                r => r.Insert(It.IsAny<Entities.Product>()),
                Times.Once);
        }
    }
}
