using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService : IGenericService<ResultCategoryDto, GetByIdCategoryDto, CreateCategoryDto, UpdateCategoryDto, Category>
    {

    }
}
