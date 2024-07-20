using JoaoHong.APICollection.Domain.Entities;
using JoaoHong.APICollection.Domain.Port.InfraStructure.Repositories;

namespace JoaoHong.APICollection.Infrastructure.Repository.Repositories
{
	public class UsersRepository : DapperRepository<Users>, IUsersRepository
	{

	}
}
