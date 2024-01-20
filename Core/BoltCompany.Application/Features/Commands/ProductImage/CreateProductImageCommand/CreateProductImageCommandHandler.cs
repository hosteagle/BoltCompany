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
            var imgUrl = await _fileService.UploadAsync(request.ImgFile);
            var addedProductImage = new Domain.Entities.ProductImage
            {
                ImageUrl = imgUrl,
                IsCoverImage = request.IsCoverImage,
                ProductId = request.ProductId,
                IsDeleted = false,
                IsModified = false
            };

            await _repository.AddAsync(addedProductImage);
            await _repository.SaveAsync();

            return new CreateProductImageCommandResponse() { Message = "Product image added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
