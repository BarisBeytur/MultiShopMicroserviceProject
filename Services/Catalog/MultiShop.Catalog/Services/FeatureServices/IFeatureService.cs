using MongoDB.Driver.Core.Misc;
using MultiShop.Catalog.Dtos.Feature;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public interface IFeatureService : IGenericService<ResultFeatureDto, GetByIdFeatureDto, CreateFeatureDto, UpdateFeatureDto, Feature>
    {
    }
}
