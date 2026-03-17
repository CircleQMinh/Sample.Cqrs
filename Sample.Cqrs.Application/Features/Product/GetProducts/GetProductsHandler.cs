
using Sample.Cqrs.Application.Abstractions.Mediator;
using Sample.Cqrs.Application.Abstractions.Repositories;
using Sample.Cqrs.Application.Features.Product.Dtos;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Sample.Cqrs.Domain.Entities;
namespace Sample.Cqrs.Application.Features.Product.GetProducts
{
    public class GetProductsHandler
        : IRequestHandler<GetProductsRequest, BaseResponse<List<ProductDto>>>
    {
        private readonly IGenericRepository<Entities.Product> _repository;

        public GetProductsHandler(
            IGenericRepository<Entities.Product> repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<List<ProductDto>>> Handle(
            GetProductsRequest request,
            CancellationToken cancellationToken)
        {
            var keyword = (!string.IsNullOrWhiteSpace(request.Search)) ? request.Search : "";
            var products = await _repository.GetAll(
                q => q.Name.Contains(keyword), 
                q => q.OrderBy(p => p.Id), 
                [], 
                new PaginationFilter { PageNumber = request.PageNumber, PageSize = request.PageSize });
            var results = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            }).ToList();

            var totalItems = await _repository.GetCount(q => q.Name.Contains(keyword));



            return new PagedResponse<List<ProductDto>>
            {
                Success = true,
                Result = results,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };
        }
    }
}
