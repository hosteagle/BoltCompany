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

        public UpdateProductImageCommandHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateProductImageCommandResponse> Handle(UpdateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereProductImageRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);

            isThereProductImageRecord.ImageUrl = request.ImageUrl;
            isThereProductImageRecord.IsCoverImage = request.IsCoverImage;
            isThereProductImageRecord.ProductId = request.ProductId;

            _repository.Update(isThereProductImageRecord);
            await _repository.SaveAsync();
            return new UpdateProductImageCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}
