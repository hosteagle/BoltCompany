using BoltCompany.Application.Repositories;
using BoltCompany.Domain.DTOs;
using MediatR;
using System.Net;

namespace BoltCompany.Application.Features.Queries.Product.GetProductWithCategoryNameByIdQuery
{
    public class GetProductWithCategoryNameByIdQueryHandler : IRequestHandler<GetProductWithCategoryNameByIdQueryRequest, GetProductWithCategoryNameByIdQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductWithCategoryNameByIdQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetProductWithCategoryNameByIdQueryResponse> Handle(GetProductWithCategoryNameByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id.ToString());
            if (product == null)
            {
                return new GetProductWithCategoryNameByIdQueryResponse { Message = "Product is not exist", StatusCode = HttpStatusCode.NotFound };
            }

            var category = await _categoryRepository.GetByIdAsync(product.CategoryId.ToString());
            if (category == null)
            {
                return new GetProductWithCategoryNameByIdQueryResponse { Message = "Category is not exist", StatusCode = HttpStatusCode.NotFound };
            }

            var result = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Specification = product.Specification,
                CategoryTitle = category.Title,
                CategoryId = category.Id,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                IsDeleted = product.IsDeleted,
                IsModified = product.IsModified
            };

            return new GetProductWithCategoryNameByIdQueryResponse { ProductWithCategoryName = result, StatusCode = HttpStatusCode.OK };
        }
    }
}
