using BoltCompany.Application.Repositories;
using BoltCompany.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.About.CreateAboutCommand
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommandRequest, CreateAboutCommandResponse>
    {
        private readonly IAboutRepository _repository;

        public CreateAboutCommandHandler(IAboutRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateAboutCommandResponse> Handle(CreateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereAboutRecord = await _repository.GetSingleAsync(d => d.Title.ToLower() == request.Title.ToLower());

            if (isThereAboutRecord != null)
                return new CreateAboutCommandResponse() { Message = "About is already exist", StatusCode = HttpStatusCode.Conflict };

            var addedAbout = new Domain.Entities.About
            {
                Title = request.Title,
                Description = request.Description,
                IsDeleted = false,
                IsModified = false
            };

            await _repository.AddAsync(addedAbout);
            await _repository.SaveAsync();

            return new CreateAboutCommandResponse() { Message = "About added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
