using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.About.UpdateAboutCommand
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommandRequest, UpdateAboutCommandResponse>
    {
        private readonly IAboutRepository _repository;

        public UpdateAboutCommandHandler(IAboutRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateAboutCommandResponse> Handle(UpdateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereAboutRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);

            isThereAboutRecord.Title = request.Title;
            isThereAboutRecord.Description = request.Description;

            _repository.Update(isThereAboutRecord);
            await _repository.SaveAsync();
            return new UpdateAboutCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}
