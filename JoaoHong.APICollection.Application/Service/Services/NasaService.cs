using JoaoHong.APICollection.Domain.Port.Application.Services;
using JoaoHong.APICollection.Domain.Port.ExternalService;

namespace JoaoHong.APICollection.Application.Service.Services
{
    public class NasaService : INasaService
    {
        private readonly INasaOpenAPIService _nasaOpenAPIService;
        public async Task<string> ListMarsPhotos()
        {
			throw new NotImplementedException();
		}

        public async Task<string> ShowMarsPhoto()
        {
            throw new NotImplementedException();
        }
    }
}
