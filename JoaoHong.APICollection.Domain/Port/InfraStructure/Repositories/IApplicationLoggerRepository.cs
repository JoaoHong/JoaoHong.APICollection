using JoaoHong.APICollection.Domain.Entities;

namespace JoaoHong.APICollection.Domain.Port.InfraStructure.Repositories
{
	public interface IApplicationLoggerRepository : IMongoCommandRepository<APILogger>
    {
    }
}
