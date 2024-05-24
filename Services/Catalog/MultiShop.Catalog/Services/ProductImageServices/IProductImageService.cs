using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService : IGenericService<ResultProductImageDto,GetByIdProductImageDto, CreateProductImageDto, UpdateProductImageDto, ProductImage>
    {
        Task<List<GetByIdProductImageDto>> GetByIdProductImageAsync(string id);
    }
}
