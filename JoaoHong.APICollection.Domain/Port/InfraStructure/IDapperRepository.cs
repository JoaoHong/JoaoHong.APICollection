using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Domain.Port.InfraStructure
{
    public interface IDapperRepository<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<long> InsertAsync(T entity);
        Task<long> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> GetByParam(params (string column, object value)[] filters);
    }
}
