using AutoMapper;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : GenericService<ResultCategoryDto, GetByIdCategoryDto, CreateCategoryDto, UpdateCategoryDto, Category>, ICategoryService
    {

        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper) : base(databaseSettings, mapper)
        {

        }


    }

}

