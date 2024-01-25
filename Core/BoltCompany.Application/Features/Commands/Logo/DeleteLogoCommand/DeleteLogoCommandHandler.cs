using BoltCompany.Application.Features.Commands.ProductImage.DeleteProductImageCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Logo.DeleteLogoCommand
{
    public class DeleteLogoCommandHandler : IRequestHandler<DeleteLogoCommandRequest, DeleteLogoCommandResponse>
    {
        private readonly ILogoRepository _repository;

        public DeleteLogoCommandHandler(ILogoRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteLogoCommandResponse> Handle(DeleteLogoCommandRequest request, CancellationToken cancellationToken)
        {
            var logoToDelete = await _repository.GetSingleAsync(c => c.Id == request.Id);

            if (logoToDelete == null) return new DeleteLogoCommandResponse { Message = "Logo is not exist", StatusCode = HttpStatusCode.NotFound };

            logoToDelete.IsDeleted = true;
            _repository.Update(logoToDelete);
            await _repository.SaveAsync();
            return new DeleteLogoCommandResponse { Message = "Logo is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
