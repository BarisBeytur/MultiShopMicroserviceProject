using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService : IGenericService<ResultProductDto, GetByIdProductDto, CreateProductDto, UpdateProductDto, Product>
    {
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId);
    }
}
