using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Port.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Application.ExternalService
{
    public class NasaOpenAPIService : INasaOpenAPIService
    {
        public Task<string> MarsPhotos(MarsPhotos model)
        {
            throw new NotImplementedException();
        }
    }
}
