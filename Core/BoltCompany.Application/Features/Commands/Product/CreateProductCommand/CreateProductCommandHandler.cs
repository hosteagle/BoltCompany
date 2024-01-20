using BoltCompany.Application.Features.Commands.Category.CreateCategoryCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Product.CreateProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereProductRecord = await _repository.GetSingleAsync(d => d.Name.ToLower() == request.Name.ToLower());

            if (isThereProductRecord != null)
                return new CreateProductCommandResponse() { Message = "Product is already exist", StatusCode = HttpStatusCode.Conflict };

            var addedProduct = new Domain.Entities.Product
            {
                Name = request.Name,
                Description = request.Description,
                Specification = request.Specification,
                IsDeleted = false,
                IsModified = false
            };

            await _repository.AddAsync(addedProduct);
            await _repository.SaveAsync();

            return new CreateProductCommandResponse() { Message = "Product added successfully", StatusCode = HttpStatusCode.Created };
        }
    }
}
