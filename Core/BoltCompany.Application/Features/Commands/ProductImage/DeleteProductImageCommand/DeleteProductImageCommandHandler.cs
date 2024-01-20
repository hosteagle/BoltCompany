using BoltCompany.Application.Features.Commands.Category.DeleteCategoryCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ProductImage.DeleteProductImageCommand
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, DeleteProductImageCommandResponse>
    {
        private readonly IProductImageRepository _repository;

        public DeleteProductImageCommandHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteProductImageCommandResponse> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var productImageToDelete = await _repository.GetSingleAsync(c => c.Id == request.Id);

            if (productImageToDelete == null) return new DeleteProductImageCommandResponse { Message = "Product image is not exist", StatusCode = HttpStatusCode.NotFound };

            productImageToDelete.IsDeleted = true;
            _repository.Update(productImageToDelete);
            await _repository.SaveAsync();
            return new DeleteProductImageCommandResponse { Message = $"{productImageToDelete.ImageUrl} is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
