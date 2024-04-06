using AutoMapper;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : GenericService<ResultProductImageDto, GetByIdProductImageDto, CreateProductImageDto, UpdateProductImageDto, ProductImage>, IProductImageService
    {
        public ProductImageService(IDatabaseSettings _databaseSettings, IMapper mapper) : base(_databaseSettings, mapper)
        {
        }
    }
}
