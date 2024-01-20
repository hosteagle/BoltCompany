using BoltCompany.Application.Features.Commands.About.UpdateAboutCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Category.UpdateCategoryCommand
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereCategoryRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);

            isThereCategoryRecord.Title = request.Title;
                                                                                                          
            _repository.Update(isThereCategoryRecord);
            await _repository.SaveAsync();
            return new UpdateCategoryCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}
