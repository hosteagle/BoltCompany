using BoltCompany.Application.Abstractions.Token;
using BoltCompany.Application.Enums;
using BoltCompany.Application.Repositories;
using MediatR;
using System.Net;

namespace BoltCompany.Application.Features.Commands.PageDetail.UpdatePageDetailCommand
{
    public class UpdatePageDetailCommandHandler : IRequestHandler<UpdatePageDetailCommandRequest, UpdatePageDetailCommandResponse>
    {
        private readonly IPageDetailRepository _repository;
        private readonly IFileService _fileService;

        public UpdatePageDetailCommandHandler(IPageDetailRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<UpdatePageDetailCommandResponse> Handle(UpdatePageDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var isTherePageDetailRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);

            var imgUrl = await _fileService.UploadAsync(request.File, FileType.Page);
            if (imgUrl is not null)
            {
                isTherePageDetailRecord.ImageUrl = imgUrl;
                isTherePageDetailRecord.ImageName = Path.GetFileName(imgUrl);
            }
            isTherePageDetailRecord.Title = request.Title;
            isTherePageDetailRecord.Description = request.Description;
            isTherePageDetailRecord.ExtraPageId = request.ExtraPageId;
            _repository.Update(isTherePageDetailRecord);
            await _repository.SaveAsync();
            return new UpdatePageDetailCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}