using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : GenericService<ResultFeatureSliderDto, GetByIdFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto, FeatureSlider> , IFeatureSliderService
    {


        private readonly IMongoCollection<FeatureSlider> _collection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IDatabaseSettings _databaseSettings, IMapper mapper) : base(_databaseSettings, mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _collection = database.GetCollection<FeatureSlider>($"{typeof(FeatureSlider)}CollectionName");

            if (_collection == null)
            {
                throw new ArgumentException($"Collection name not found for type {typeof(FeatureSlider).Name}");
            }

            _mapper = mapper;
        }

        public Task ChangeFeatureSliderStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task ChangeFeatureSliderStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }
    }
}
