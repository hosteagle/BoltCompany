using BoltCompany.Application.Abstractions.Token;
using BoltCompany.Application.Enums;
using BoltCompany.Application.Features.Commands.ProductImage.UpdateProductImageCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Logo.UpdateLogoCommand
{
    public class UpdateLogoCommandHandler : IRequestHandler<UpdateLogoCommandRequest, UpdateLogoCommandResponse>
    {
        private readonly ILogoRepository _repository;
        private readonly IFileService _fileService;

        public UpdateLogoCommandHandler(ILogoRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<UpdateLogoCommandResponse> Handle(UpdateLogoCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereLogoRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);
            if (request.Logo != null)
            {
                var logo = await _fileService.UploadAsync(request.Logo, FileType.Logo);
                isThereLogoRecord.LogoUrl = logo;
                isThereLogoRecord.LogoName = Path.GetFileName(logo);
            }
            if (request.Icon != null)
            {
                var icon = await _fileService.UploadAsync(request.Icon, FileType.Logo);
                isThereLogoRecord.IconUrl = icon;
                isThereLogoRecord.IconName = Path.GetFileName(icon);
            }
            _repository.Update(isThereLogoRecord);
            await _repository.SaveAsync();
            return new UpdateLogoCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}
