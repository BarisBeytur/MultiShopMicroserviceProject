using AutoMapper;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : GenericService<ResultProductDetailDto, GetByIdProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto, ProductDetail>, IProductDetailService
    {
        public ProductDetailService(IDatabaseSettings _databaseSettings, IMapper mapper) : base(_databaseSettings, mapper)
        {
        }
    }
}
