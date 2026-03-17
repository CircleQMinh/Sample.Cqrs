
using Sample.Cqrs.Application.Abstractions.Mediator;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.Product.DeleteProduct
{
    public record DeleteProductRequest(int Id)
        : IRequest<BaseResponse<string>>;
}
