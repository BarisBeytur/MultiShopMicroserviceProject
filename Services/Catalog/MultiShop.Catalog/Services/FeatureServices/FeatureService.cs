using AutoMapper;
using MultiShop.Catalog.Dtos.Feature;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : GenericService<ResultFeatureDto, GetByIdFeatureDto, CreateFeatureDto, UpdateFeatureDto, Feature>, IFeatureService
    {

        public FeatureService(IDatabaseSettings databaseSettings, IMapper mapper) : base(databaseSettings, mapper)
        {

        }
    }
}
