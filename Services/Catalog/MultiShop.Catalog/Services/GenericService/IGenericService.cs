using MultiShop.Catalog.Dtos.Product;

namespace MultiShop.Catalog.Services.GenericService
{
    public interface IGenericService<TResult, TGetById, TCreate, TUpdate, TEntity> where TResult : class where TGetById : class where TCreate : class where TUpdate : class where TEntity : class
    {
        Task<List<TResult>> GetAllAsync();
        Task<TGetById> GetByIdAsync(string id);
        Task CreateAsync(TCreate TCreateDto);
        Task UpdateAsync(TUpdate TUpdateDto);
        Task DeleteAsync(string id);
    }
}
