using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Application.Features.Product.DeleteProduct
{
    public class DeleteProductValidator
     : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}
