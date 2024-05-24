using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : GenericService<ResultProductImageDto, GetByIdProductImageDto, CreateProductImageDto, UpdateProductImageDto, ProductImage>, IProductImageService
    {

        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IDatabaseSettings _databaseSettings, IMapper mapper) : base(_databaseSettings, mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>($"{typeof(ProductImage)}CollectionName");

            _mapper = mapper;
        }

        public async Task<List<GetByIdProductImageDto>> GetByIdProductImageAsync(string id)
        {
            var values = await _productImageCollection.Find(x => x.ProductId == id).ToListAsync();
            return _mapper.Map<List<GetByIdProductImageDto>>(values);
        }
    }
}
