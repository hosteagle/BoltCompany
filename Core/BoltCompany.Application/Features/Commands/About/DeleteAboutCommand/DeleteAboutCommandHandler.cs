using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.About.DeleteAboutCommand
{
    public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommandRequest, DeleteAboutCommandResponse>
    {
        private readonly IAboutRepository _repository;

        public DeleteAboutCommandHandler(IAboutRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteAboutCommandResponse> Handle(DeleteAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var aboutToDelete = await _repository.GetSingleAsync(c => c.Id == request.Id);

            if (aboutToDelete == null) return new DeleteAboutCommandResponse { Message = "About is not exist", StatusCode = HttpStatusCode.NotFound };

            aboutToDelete.IsDeleted = true;
            _repository.Update(aboutToDelete);
            await _repository.SaveAsync();
            return new DeleteAboutCommandResponse { Message = $"{aboutToDelete.Title} is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
