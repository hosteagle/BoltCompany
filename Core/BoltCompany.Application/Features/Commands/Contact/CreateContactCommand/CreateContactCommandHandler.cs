using BoltCompany.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace BoltCompany.Application.Features.Commands.Contact.CreateContactCommand
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, CreateContactCommandResponse>
    {
        private readonly IContactRepository _repository;

        public CreateContactCommandHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateContactCommandResponse> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Contact> contacts = new List<Domain.Entities.Contact>();

            for (int i = 0; i < request.ContactList.Count; i++)
            {
                var addedContact = new Domain.Entities.Contact
                {
                    ContactType = request.ContactList[i].ContactType,
                    Key = request.ContactList[i].Key,
                    Value = request.ContactList[i].Value,
                    IsDeleted = false,
                    IsModified = false
                };

                contacts.Add(addedContact);
            }

            await _repository.AddRangeAsync(contacts);
            await _repository.SaveAsync();

            return new CreateContactCommandResponse() { Message = "Contact added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
