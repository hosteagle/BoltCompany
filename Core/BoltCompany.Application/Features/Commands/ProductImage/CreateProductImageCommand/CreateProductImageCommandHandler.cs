using BoltCompany.Application.Abstractions.Token;
using BoltCompany.Application.Features.Commands.Product.CreateProductCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.ProductImage.CreateProductImageCommand
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommandRequest, CreateProductImageCommandResponse>
    {
        private readonly IProductImageRepository _repository;
        private readonly IFileService _fileService;

        public CreateProductImageCommandHandler(IProductImageRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<CreateProductImageCommandResponse> Handle(CreateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<string> imageUrls = new List<string>();

            foreach (var file in request.Files)
            {
                var imgUrl = await _fileService.UploadAsync(file);

                imageUrls.Add(imgUrl);
            }

            var productImages = imageUrls.Select((imgUrl) => new Domain.Entities.ProductImage
            {
                ImageUrl = imgUrl,
                ImageName = Path.GetFileName(imgUrl),
                IsCoverImage = request.IsCoverImage,
                ProductId = request.ProductId,
                IsDeleted = false,
                IsModified = false
            });;

            await _repository.AddRangeAsync(productImages);
            await _repository.SaveAsync();

            return new CreateProductImageCommandResponse() { Message = "Product images added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
