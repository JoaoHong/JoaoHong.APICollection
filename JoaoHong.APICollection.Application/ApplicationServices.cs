using JoaoHong.APICollection.Application.ExternalService;
using JoaoHong.APICollection.Application.Service.Services;
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
			return service;
		}
	}
}
