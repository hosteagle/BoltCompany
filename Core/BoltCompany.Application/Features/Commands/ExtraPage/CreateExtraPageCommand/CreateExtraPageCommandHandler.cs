using BoltCompany.Application.Features.Commands.About.CreateAboutCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ExtraPage.CreateExtraPageCommand
{
    public class CreateExtraPageCommandHandler : IRequestHandler<CreateExtraPageCommandRequest, CreateExtraPageCommandResponse>
    {
        private readonly IExtraPageRepository _repository;

        public CreateExtraPageCommandHandler(IExtraPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateExtraPageCommandResponse> Handle(CreateExtraPageCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereExtraPageRecord = await _repository.GetSingleAsync(d => d.PageName.ToLower() == request.PageName.ToLower());

            if (isThereExtraPageRecord != null)
                return new CreateExtraPageCommandResponse() { Message = "Page is already exist", StatusCode = HttpStatusCode.Conflict };

            var formattedPageName = request.PageName.ToLower().Replace(" ", "-");
            var formattedPath = "/" + formattedPageName;

            var addedPage = new Domain.Entities.ExtraPage
            {
                PageName = request.PageName,
                PageTitle = request.PageTitle,
                Path = formattedPath,
                IsDeleted = false,
                IsModified = false
            };

            await _repository.AddAsync(addedPage);
            await _repository.SaveAsync();

            return new CreateExtraPageCommandResponse() { Message = "Page added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
