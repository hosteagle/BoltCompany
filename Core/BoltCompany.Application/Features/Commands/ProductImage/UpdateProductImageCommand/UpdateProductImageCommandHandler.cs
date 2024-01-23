using BoltCompany.Application.Abstractions.Token;
using BoltCompany.Application.Features.Commands.Category.UpdateCategoryCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ProductImage.UpdateProductImageCommand
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommandRequest, UpdateProductImageCommandResponse>
    {
        private readonly IProductImageRepository _repository;
        private readonly IFileService _fileService;


        public UpdateProductImageCommandHandler(IProductImageRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<UpdateProductImageCommandResponse> Handle(UpdateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereProductImageRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);

            List<string> imageUrls = new List<string>();

            foreach (var file in request.Files)
            {
                var imgUrl = await _fileService.UploadAsync(file);

                imageUrls.Add(imgUrl);
            }

            isThereProductImageRecord.ImageUrl = imageUrls.FirstOrDefault();
            isThereProductImageRecord.ImageName = Path.GetFileName(imageUrls.FirstOrDefault());
            isThereProductImageRecord.IsCoverImage = request.IsCoverImage;
            isThereProductImageRecord.ProductId = request.ProductId;

            _repository.Update(isThereProductImageRecord);
            await _repository.SaveAsync();
            return new UpdateProductImageCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}
