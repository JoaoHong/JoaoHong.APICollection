using JoaoHong.APICollection.Domain.Port.InfraStructure;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Infrastructure.Repository
{
    public class MongoCommandRepository<T> : IMongoCommandRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoCommandRepository(IMongoContextDB mongoContextDB)
        {
            var databaseTask = mongoContextDB.Connection();
            _collection = databaseTask.Result.GetCollection<T>(mongoContextDB.CollectionName());
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
