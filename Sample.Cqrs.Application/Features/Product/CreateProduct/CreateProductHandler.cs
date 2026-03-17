
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
namespace Sample.Cqrs.Application.Features.Product.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, BaseResponse<ProductDto>>
    {
        private readonly IGenericRepository<Entities.Product> _repository;
        private readonly IUserContext _context;
        public CreateProductHandler(IGenericRepository<Entities.Product> repository, IUserContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<BaseResponse<ProductDto>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Entities.Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                    Price = request.Price,
                    StockQuantity = request.StockQuantity,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = _context.Email
                };

                await _repository.Insert(product);

                await _repository.SaveChangesAsync();

                return new BaseResponse<ProductDto>
                {
                    Message = "Product created successfully.",
                    Success = true,
                    Result = new ProductDto
                    {
                        Description = request.Description,
                        ImageUrl = request.ImageUrl,
                        Price = request.Price,
                        StockQuantity = request.StockQuantity,
                        Id = product.Id,
                        Name = request.Name,
                    }
                };
            }
            catch (Exception e)
            {

                return new BaseResponse<ProductDto>
                {
                    Errors = new List<string> { e.Message },
                    Message = e.Message,
                    Success = false,
                };
            }

        }
    }
}
