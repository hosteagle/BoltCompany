using BoltCompany.Application.Features.Commands.ProductImage.DeleteProductImageCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.PageDetail.DeletePageDetailCommand
{
    public class DeletePageDetailCommandHandler : IRequestHandler<DeletePageDetailCommandRequest, DeletePageDetailCommandResponse>
    {
        private readonly IPageDetailRepository _repository;

        public DeletePageDetailCommandHandler(IPageDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeletePageDetailCommandResponse> Handle(DeletePageDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var pageDetailToDelete = await _repository.GetSingleAsync(c => c.Id == request.Id);

            if (pageDetailToDelete == null) return new DeletePageDetailCommandResponse { Message = $"{pageDetailToDelete.Title} is not exist", StatusCode = HttpStatusCode.NotFound };

            pageDetailToDelete.IsDeleted = true;
            _repository.Update(pageDetailToDelete);
            await _repository.SaveAsync();
            return new DeletePageDetailCommandResponse { Message = $"{pageDetailToDelete.Title} is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
