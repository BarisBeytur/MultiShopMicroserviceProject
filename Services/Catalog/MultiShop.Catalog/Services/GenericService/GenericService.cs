using AutoMapper;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Collections;

namespace MultiShop.Catalog.Services.GenericService
{
    public class GenericService<TResult, TGetById, TCreate, TUpdate, TEntity> : IGenericService<TResult, TGetById, TCreate, TUpdate, TEntity>
        where TResult : class
        where TGetById : class
        where TCreate : class
        where TUpdate : class
        where TEntity : class, IEntity
    {

        private readonly IMongoCollection<TEntity> _collection;
        private readonly IMapper _mapper;

        public GenericService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _collection = database.GetCollection<TEntity>($"{nameof(TEntity)}CollectionName");

            if (_collection == null)
            {
                throw new ArgumentException($"Collection name not found for type {typeof(TEntity).Name}");
            }

            _mapper = mapper;
        }

        public async Task CreateAsync(TCreate TCreateDto)
        {
            var value = _mapper.Map<TEntity>(TCreateDto);
            await _collection.InsertOneAsync(value);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<TResult>> GetAllAsync()
        {
            var values = await _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<TResult>>(values);
        }

        public async Task<TGetById> GetByIdAsync(string id)
        {
            var value = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<TGetById>(value);
        }

        public async Task UpdateAsync(TUpdate TUpdateDto)
        {
            var value = _mapper.Map<TEntity>(TUpdateDto);

            await _collection.ReplaceOneAsync(x => x.Id == value.Id, value);

        }
    }
}
