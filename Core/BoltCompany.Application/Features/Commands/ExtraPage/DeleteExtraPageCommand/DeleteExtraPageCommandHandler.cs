using BoltCompany.Application.Repositories;
using MediatR;
using System.Net;

namespace BoltCompany.Application.Features.Commands.ExtraPage.DeleteExtraPageCommand
{
    public class DeleteExtraPageCommandHandler : IRequestHandler<DeleteExtraPageCommandRequest, DeleteExtraPageCommandResponse>
    {
        private readonly IExtraPageRepository _repository;

        public DeleteExtraPageCommandHandler(IExtraPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteExtraPageCommandResponse> Handle(DeleteExtraPageCommandRequest request, CancellationToken cancellationToken)
        {
            var extraPageToDelete = await _repository.GetSingleAsync(c => c.Id == request.Id);

            if (extraPageToDelete == null) return new DeleteExtraPageCommandResponse { Message = $"{extraPageToDelete.PageName} is not exist", StatusCode = HttpStatusCode.NotFound };

            extraPageToDelete.IsDeleted = true;
            _repository.Update(extraPageToDelete);
            await _repository.SaveAsync();
            return new DeleteExtraPageCommandResponse { Message = $"{extraPageToDelete.PageName} is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
