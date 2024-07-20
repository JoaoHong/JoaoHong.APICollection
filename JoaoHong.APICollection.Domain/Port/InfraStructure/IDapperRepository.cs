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
