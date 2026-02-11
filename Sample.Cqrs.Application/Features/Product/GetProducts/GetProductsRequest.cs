using MediatR;
using Sample.Cqrs.Application.Features.Product.Dtos;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.Product.GetProducts
{
    public sealed record GetProductsRequest(
        string? Search,
        int PageNumber = 1,
        int PageSize = 10
    ) : IRequest<BaseResponse<List<ProductDto>>>;
}
