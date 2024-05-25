using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : GenericService<ResultProductDetailDto, GetByIdProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto, ProductDetail>, IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IDatabaseSettings _databaseSettings, IMapper mapper) : base(_databaseSettings, mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>($"{typeof(ProductDetail)}CollectionName");

            _mapper = mapper;
        }


        public async Task<GetByIdProductDetailDto> GetProductDetailByProductId(string id)
        {
            var value = await _productDetailCollection.Find<ProductDetail>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }
    }
}
