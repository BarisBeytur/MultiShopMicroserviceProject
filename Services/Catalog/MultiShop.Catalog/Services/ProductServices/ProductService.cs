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
        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper) : base(databaseSettings, mapper)
        {

        }
    }

}
