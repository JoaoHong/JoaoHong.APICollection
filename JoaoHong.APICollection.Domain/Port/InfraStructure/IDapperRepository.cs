namespace JoaoHong.APICollection.Domain.Port.InfraStructure
{
	public interface IDapperRepository<T>
    {
        Task<T> GetById(int id);
        Task<long> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetByParam(params (string column, object value)[] filters);
    }
}
