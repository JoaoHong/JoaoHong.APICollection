using JoaoHong.APICollection.Domain.Port.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Infrastructure.Repository
{
    public abstract class DapperRepository<T> : IDapperRepository<T>
    {
        private readonly IMySQLContextDB _mySqlContext;
        private readonly string _connectionString;

        public DapperRepository(IMySQLContextDB mySQLContext, string connectionString = null)
        {
            _mySqlContext = mySQLContext;
            _connectionString = connectionString;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetByParam(params (string column, object value)[] filters)
        {
            throw new NotImplementedException();
        }

        public Task<long> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
