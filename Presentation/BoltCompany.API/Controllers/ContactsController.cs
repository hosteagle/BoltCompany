using BoltCompany.Application.Features.Commands.Contact.CreateContactCommand;
using BoltCompany.Application.Features.Commands.Contact.DeleteContactCommand;
using BoltCompany.Application.Features.Commands.Contact.UpdateContactCommand;
using BoltCompany.Application.Features.Queries.Contact.GetContactByIdQuery;
using BoltCompany.Application.Features.Queries.Contact.GetContactsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseApiController
    {
        private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await _mediator.Send(new GetContactsQueryRequest());
        return CreateActionResultInstance<GetContactsQueryResponse>(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetContactByIdQueryRequest { Id = id });
        return CreateActionResultInstance<GetContactByIdQueryResponse>(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateContactCommandRequest createContact)
    {
        var result = await _mediator.Send(createContact);
        return CreateActionResultInstance<CreateContactCommandResponse>(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateContactCommandRequest updateContact)
    {
        var result = await _mediator.Send(updateContact);
        return CreateActionResultInstance<UpdateContactCommandResponse>(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteContactCommandRequest deleteContact)
    {
        var result = await _mediator.Send(deleteContact);
        return CreateActionResultInstance<DeleteContactCommandResponse>(result);
    }
}
}
