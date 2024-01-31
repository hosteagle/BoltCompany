using BoltCompany.Application.Features.Commands.About.UpdateAboutCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Contact.UpdateContactCommand
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommandRequest, UpdateContactCommandResponse>
    {
        private readonly IContactRepository _repository;

        public UpdateContactCommandHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateContactCommandResponse> Handle(UpdateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereContactRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);

            isThereContactRecord.ContactType = request.ContactType;
            isThereContactRecord.Key = request.Key;
            isThereContactRecord.Value = request.Value;

            _repository.Update(isThereContactRecord);
            await _repository.SaveAsync();
            return new UpdateContactCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}
