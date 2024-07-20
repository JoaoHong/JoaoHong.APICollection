using JoaoHong.APICollection.Domain.DTO;

namespace JoaoHong.APICollection.Domain.Port.ExternalService
{
	public interface IJokeAPIService
	{
		Task<string> GetJoke(ConsultarPiada model);
	}
}
