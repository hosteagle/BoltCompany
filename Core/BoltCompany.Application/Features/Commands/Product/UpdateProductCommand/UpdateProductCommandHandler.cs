using BoltCompany.Application.Features.Commands.Category.UpdateCategoryCommand;
using BoltCompany.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.Product.UpdateProductCommand
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereProductRecord = await _repository.GetSingleAsync(c => c.Id == request.Id);

            isThereProductRecord.Name = request.Name;
            isThereProductRecord.Description = request.Description;
            isThereProductRecord.Specification = request.Specification;
            isThereProductRecord.CategoryId = request.CategoryId;

            _repository.Update(isThereProductRecord);
            await _repository.SaveAsync();
            return new UpdateProductCommandResponse() { StatusCode = HttpStatusCode.OK };
        }
    }
}
