using AutoMapper;
using MultiShop.Catalog.Dtos.Brand;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandService
{
    public class BrandService : GenericService<ResultBrandDto, GetByIdBrandDto, CreateBrandDto, UpdateBrandDto, Brand>, IBrandService
    {
        public BrandService(IDatabaseSettings databaseSettings, IMapper mapper) : base(databaseSettings, mapper)
        {

        }
    }
}
