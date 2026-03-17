
using Sample.Cqrs.Application.Abstractions.Mediator;
using Sample.Cqrs.Application.Abstractions.Repositories;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Application.Features.Product.Dtos;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Sample.Cqrs.Domain.Entities;
namespace Sample.Cqrs.Application.Features.Product.UpdateProduct
{
    public class UpdateProductHandler
        : IRequestHandler<UpdateProductRequest, BaseResponse<ProductDto>>
    {
        private readonly IGenericRepository<Entities.Product> _repository;
        private readonly IUserContext _context;
        public UpdateProductHandler(
            IGenericRepository<Entities.Product> repository, IUserContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<BaseResponse<ProductDto>> Handle(
            UpdateProductRequest request,
            CancellationToken cancellationToken)
        {
            var product = await _repository.Get(q => q.Id == request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
                //return BaseResponse<ProductDto>.Failure(
                //    new[] { "Product not found." });
            }

            // Update fields
            product.Name = request.Name;
            product.Description = request.Description;
            product.ImageUrl = request.ImageUrl;
            product.Price = request.Price;
            product.StockQuantity = request.StockQuantity;
            product.UpdatedDate = DateTime.UtcNow;
            product.UpdatedBy = _context.Email;

            _repository.Update(product);
            await _repository.SaveChangesAsync();

            return new BaseResponse<ProductDto>
            {
                Success = true,
                Message = "Product updated successfully.",
                Result = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity
                }
            };
        }
    }

}
