using BoltCompany.Application.Features.Commands.About.CreateAboutCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Category.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereCategoryRecord = await _repository.GetSingleAsync(d => d.Title.ToLower() == request.Title.ToLower());

            if (isThereCategoryRecord != null)
                return new CreateCategoryCommandResponse() { Message = "Category is already exist", StatusCode = HttpStatusCode.Conflict };

            var addedAbout = new Domain.Entities.Category
            {
                Title = request.Title,
                IsDeleted = false,
                IsModified = false
            };

            await _repository.AddAsync(addedAbout);
            await _repository.SaveAsync();

            return new CreateCategoryCommandResponse() { Message = "Category added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
