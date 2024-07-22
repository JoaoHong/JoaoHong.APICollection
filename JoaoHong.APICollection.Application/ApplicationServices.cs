using JoaoHong.APICollection.Application.ExternalService;
using JoaoHong.APICollection.Application.Service;
using JoaoHong.APICollection.Application.Service.Services;
using JoaoHong.APICollection.Domain.Port.Application;
using JoaoHong.APICollection.Domain.Port.Application.Services;
using JoaoHong.APICollection.Domain.Port.ExternalService;
using Microsoft.Extensions.DependencyInjection;

namespace JoaoHong.APICollection.Application
{
    public static class ApplicationServices
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection service) 
		{
			service.AddScoped<IJokeAPIService, JokeAPIService>();
			service.AddScoped<INasaOpenAPIService, NasaOpenAPIService>();
			service.AddScoped<INasaService, NasaService>();			
			service.AddScoped<IUserService, UserService>();
			service.AddScoped<IEncryptionService, EncryptionService>();
			return service;
		}
	}
}
