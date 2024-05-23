using MultiShop.Catalog.Dtos.Brand;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.BrandService
{
    public interface IBrandService : IGenericService<ResultBrandDto, GetByIdBrandDto, CreateBrandDto, UpdateBrandDto, Brand>
    {
    }
}
