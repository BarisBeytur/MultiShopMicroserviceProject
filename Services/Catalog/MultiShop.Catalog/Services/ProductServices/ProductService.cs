using AutoMapper;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : GenericService<ResultProductDto, GetByIdProductDto, CreateProductDto, UpdateProductDto, Product>, IProductService
    {

        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IDatabaseSettings _databaseSettings, IMapper mapper) : base(_databaseSettings, mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>($"{typeof(Category)}CollectionName");
            _productCollection = database.GetCollection<Product>($"{typeof(Product)}CollectionName");

            _mapper = mapper;
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {

            var values = await _productCollection.Find(x => true).ToListAsync();

            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();
            }

            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);

        }
    }

}
