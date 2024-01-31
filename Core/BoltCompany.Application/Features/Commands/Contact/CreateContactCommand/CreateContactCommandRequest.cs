using MediatR;

namespace BoltCompany.Application.Features.Commands.Contact.CreateContactCommand
{
    public class CreateContactCommandRequest : IRequest<CreateContactCommandResponse>
    {
        public List<ContactInput> ContactList { get; set; }
    }

    public class ContactInput
    {
        public string ContactType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
