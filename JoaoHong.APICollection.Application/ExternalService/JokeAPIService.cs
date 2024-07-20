using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Port.ExternalService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JoaoHong.APICollection.Application.ExternalService
{
	public class JokeAPIService : IJokeAPIService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;

		public JokeAPIService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}
		public async Task<string> GetJoke(ConsultarPiada model)
		{
			var url = _configuration["JokeAPI:URL"];

			try
			{
				var response = await _httpClient.GetAsync(url);

				response.EnsureSuccessStatusCode();

				var responseBody = await response.Content.ReadAsStringAsync();

				var jokeResponse = JsonConvert.DeserializeObject<JokeResponse>(responseBody);

				if (jokeResponse.Type == "single")
				{
					return jokeResponse.Joke;
				}
				else if (jokeResponse.Type == "twopart")
				{
					return $"{jokeResponse.Setup} - {jokeResponse.Delivery}";
				}
				return "No joke found";
			}
			catch (Exception ex) 
			{
				throw new Exception(ex.Message);
			}
		}
	}
	public class JokeResponse
	{
		public string Type { get; set; }
		public string Setup { get; set; }
		public string Delivery { get; set; }
		public string Joke { get; set; }
	}
}
