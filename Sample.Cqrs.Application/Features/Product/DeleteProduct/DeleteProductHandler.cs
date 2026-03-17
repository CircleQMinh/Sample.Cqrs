
using Sample.Cqrs.Application.Abstractions.Mediator;
using Sample.Cqrs.Application.Abstractions.Repositories;
using Sample.Cqrs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Sample.Cqrs.Domain.Entities;
namespace Sample.Cqrs.Application.Features.Product.DeleteProduct
{
    public class DeleteProductHandler
        : IRequestHandler<DeleteProductRequest, BaseResponse<string>>
    {
        private readonly IGenericRepository<Entities.Product> _repository;

        public DeleteProductHandler(
            IGenericRepository<Entities.Product> repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<string>> Handle(
            DeleteProductRequest request,
            CancellationToken cancellationToken)
        {
            var product = await _repository.Get(q => q.Id == request.Id);

            if (product == null)
            {
                //return BaseResponse<string>.Failure(
                //    new[] { "Product not found." });
                throw new KeyNotFoundException("Product not found.");
            }

            await _repository.Delete(product.Id);
            await _repository.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Result = "Product deleted successfully."
            };
        }
    }

}
