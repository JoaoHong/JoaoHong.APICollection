using JoaoHong.APICollection.Domain.Port.InfraStructure;
using JoaoHong.APICollection.Domain.Port.InfraStructure.Repositories;
using JoaoHong.APICollection.Infrastructure.Context;
using JoaoHong.APICollection.Infrastructure.Repository;
using JoaoHong.APICollection.Infrastructure.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JoaoHong.APICollection.Infrastructure
{
	public static class InfrastructureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection service) 
		{
			service.AddScoped<IMySQLContextDB, MySQLContextDB>();
			service.AddScoped<IMongoContextDB, MongoContextDB>();
			service.AddScoped<IApplicationLoggerRepository, ApplicationLoggerRepository>();
			service.AddScoped<IUsersRepository, UsersRepository>();
			return service;
		}
	}
}
