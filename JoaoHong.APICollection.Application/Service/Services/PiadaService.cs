using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Port.Application.Services;
using JoaoHong.APICollection.Domain.Port.ExternalService;

namespace JoaoHong.APICollection.Application.Service.Services
{
    public class PiadaService : IPiadaService
	{
		private readonly IJokeAPIService _jokeServie;
		public Task<string> FindJoke(ConsultarPiada model)
		{
			try
			{
				var getjoke = _jokeServie.GetJoke(model);

				return getjoke;
			}
			catch (Exception ex) 
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
