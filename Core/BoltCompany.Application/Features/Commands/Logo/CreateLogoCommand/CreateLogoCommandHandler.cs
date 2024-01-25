using BoltCompany.Application.Abstractions.Token;
using BoltCompany.Application.Enums;
using BoltCompany.Application.Features.Commands.ProductImage.CreateProductImageCommand;
using BoltCompany.Application.Repositories;
using BoltCompany.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Logo.CreateLogoCommand
{
    public class CreateLogoCommandHandler : IRequestHandler<CreateLogoCommandRequest, CreateLogoCommandResponse>
    {
        private readonly ILogoRepository _repository;
        private readonly IFileService _fileService;

        public CreateLogoCommandHandler(ILogoRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<CreateLogoCommandResponse> Handle(CreateLogoCommandRequest request, CancellationToken cancellationToken)
        {
            var logo = await _fileService.UploadAsync(request.Logo, FileType.Logo);
            var icon = await _fileService.UploadAsync(request.Icon, FileType.Logo);

            var addedLogo = new Domain.Entities.Logo
            {
                LogoUrl = logo,
                LogoName = Path.GetFileName(logo),
                IconUrl = icon,
                IconName = Path.GetFileName(icon),
                IsDeleted = false,
                IsModified = false
            };

            await _repository.AddAsync(addedLogo);
            await _repository.SaveAsync();

            return new CreateLogoCommandResponse() { Message = "Logos added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
