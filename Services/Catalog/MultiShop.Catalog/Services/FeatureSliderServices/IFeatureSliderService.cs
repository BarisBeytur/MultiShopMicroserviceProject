using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService : IGenericService<ResultFeatureSliderDto, GetByIdFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto, FeatureSlider>
    {
        Task ChangeFeatureSliderStatusToTrue(string id);
        Task ChangeFeatureSliderStatusToFalse(string id);
    }
}
