using BoltCompany.Application.Features.Queries.Product.GetProductsQuery;
using BoltCompany.Application.Repositories;
using BoltCompany.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BoltCompany.Application.Features.Queries.Product.GetProductsWithCategoryNameQuery
{
    public class GetProductsWithCategoryNameQueryHandler : IRequestHandler<GetProductsWithCategoryNameQueryRequest, GetProductsWithCategoryNameQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductsWithCategoryNameQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetProductsWithCategoryNameQueryResponse> Handle(GetProductsWithCategoryNameQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(p => p.IsDeleted == false, false);
            var categories = await _categoryRepository.GetAllAsync(c => c.IsDeleted == false, false);

            var result = from product in products
                         join category in categories on product.CategoryId equals category.Id
                         select new ProductDto
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

            return new GetProductsWithCategoryNameQueryResponse { ProductsWithCategoryName = result, StatusCode = HttpStatusCode.OK };
        }
    }
}
