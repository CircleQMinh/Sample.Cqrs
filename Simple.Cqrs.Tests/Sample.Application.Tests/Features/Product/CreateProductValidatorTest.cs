using Sample.Cqrs.Application.Features.Product.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sample.Cqrs.Tests.Sample.Application.Tests.Features.Product
{
    public class CreateProductValidatorTest
    {
        private readonly CreateProductValidator _validator;

        public CreateProductValidatorTest()
        {
            _validator = new CreateProductValidator();
        }

        [Fact]
        public void CreateProductValidator_WrongInput_ShouldFail()
        {
            // Arrange
            var request = new CreateProductRequest(
                "",
                "Description",
                "image.jpg",
                10,
                5);

            // Act
            var result = _validator.Validate(request);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Name");

        }
    }
}
