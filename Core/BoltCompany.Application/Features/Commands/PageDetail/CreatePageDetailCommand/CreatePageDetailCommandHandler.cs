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

namespace BoltCompany.Application.Features.Commands.PageDetail.CreatePageDetailCommand
{
    public class CreatePageDetailCommandHandler : IRequestHandler<CreatePageDetailCommandRequest, CreatePageDetailCommandResponse>
    {
        private readonly IPageDetailRepository _repository;
        private readonly IFileService _fileService;

        public CreatePageDetailCommandHandler(IPageDetailRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<CreatePageDetailCommandResponse> Handle(CreatePageDetailCommandRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.PageDetail> pageDetails = new List<Domain.Entities.PageDetail>();
            for (int i = 0; i < request.PageDetailList.Count; i++)
            {
                var imgUrl = await _fileService.UploadAsync(request.PageDetailList[i].File, FileType.Page);
                var pageDetail = new Domain.Entities.PageDetail
                {
                    Title = request.PageDetailList[i].Title,
                    Description = request.PageDetailList[i].Description,
                    ImageUrl = imgUrl,
                    ImageName = Path.GetFileName(imgUrl),
                    ExtraPageId = request.PageDetailList[i].ExtraPageId,
                    IsDeleted = false,
                    IsModified = false
                };

                pageDetails.Add(pageDetail);
            }

            await _repository.AddRangeAsync(pageDetails);
            await _repository.SaveAsync();

            return new CreatePageDetailCommandResponse() { Message = "Page Details added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
