using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Domain.Port.InfraStructure
{
    public interface IMongoCommandRepository<T>
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity); 
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
