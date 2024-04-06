using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService : IGenericService<ResultProductDetailDto, GetByIdProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto, ProductDetail>
    {
    }
}
