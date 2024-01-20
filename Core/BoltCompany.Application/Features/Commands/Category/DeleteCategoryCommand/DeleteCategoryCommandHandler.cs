using BoltCompany.Application.Features.Commands.About.DeleteAboutCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Category.DeleteCategoryCommand
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _repository.GetSingleAsync(c => c.Id == request.Id);

            if (categoryToDelete == null) return new DeleteCategoryCommandResponse { Message = "Category is not exist", StatusCode = HttpStatusCode.NotFound };

            categoryToDelete.IsDeleted = true;
            _repository.Update(categoryToDelete);
            await _repository.SaveAsync();
            return new DeleteCategoryCommandResponse { Message = $"{categoryToDelete.Title} is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
