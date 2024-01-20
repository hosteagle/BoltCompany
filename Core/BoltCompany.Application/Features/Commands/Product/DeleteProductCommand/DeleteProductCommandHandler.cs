using BoltCompany.Application.Features.Commands.Category.DeleteCategoryCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Product.DeleteProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var productToDelete = await _repository.GetSingleAsync(c => c.Id == request.Id);

            if (productToDelete == null) return new DeleteProductCommandResponse { Message = "Product is not exist", StatusCode = HttpStatusCode.NotFound };

            productToDelete.IsDeleted = true;
            _repository.Update(productToDelete);
            await _repository.SaveAsync();
            return new DeleteProductCommandResponse { Message = $"{productToDelete.Name} is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
