using MediatR;
using Sample.Cqrs.Application.Features.Product.Dtos;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.Product.CreateProduct
{
    public record CreateProductRequest(
        string Name,
        string Description,
        string ImageUrl,
        decimal Price,
        int StockQuantity
    ) : IRequest<BaseResponse<ProductDto>>; // return created product 
}
