using BoltCompany.Application.Features.Commands.ProductImage.DeleteProductImageCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Contact.DeleteContactCommand
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommandRequest, DeleteContactCommandResponse>
    {
        private readonly IContactRepository _repository;

        public DeleteContactCommandHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteContactCommandResponse> Handle(DeleteContactCommandRequest request, CancellationToken cancellationToken)
        {
            var contactToDelete = await _repository.GetSingleAsync(c => c.Id == request.Id);

            if (contactToDelete == null) return new DeleteContactCommandResponse { Message = $"{contactToDelete.Key} is not exist", StatusCode = HttpStatusCode.NotFound };

            contactToDelete.IsDeleted = true;
            _repository.Update(contactToDelete);
            await _repository.SaveAsync();
            return new DeleteContactCommandResponse { Message = $"{contactToDelete.Key} is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
