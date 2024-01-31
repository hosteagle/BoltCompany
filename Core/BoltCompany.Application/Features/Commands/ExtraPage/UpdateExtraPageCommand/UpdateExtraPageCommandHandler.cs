using BoltCompany.Application.Features.Commands.About.UpdateAboutCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ExtraPage.UpdateExtraPageCommand
{
    public class UpdateExtraPageCommandHandler : IRequestHandler<UpdateExtraPageCommandRequest, UpdateExtraPageCommandResponse>
    {
        private readonly IExtraPageRepository _repository;

        public UpdateExtraPageCommandHandler(IExtraPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateExtraPageCommandResponse> Handle(UpdateExtraPageCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereExtraPageRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);

            var formattedPageName = request.PageName.ToLower().Replace(" ", "-");
            var formattedPath = "/" + formattedPageName;

            isThereExtraPageRecord.PageName = request.PageName;
            isThereExtraPageRecord.PageTitle = request.PageTitle;
            isThereExtraPageRecord.Path = formattedPath;
            _repository.Update(isThereExtraPageRecord);
            await _repository.SaveAsync();
            return new UpdateExtraPageCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}
