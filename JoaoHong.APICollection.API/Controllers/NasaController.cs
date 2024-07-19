using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Port.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoaoHong.APICollection.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NasaController : ControllerBase
    {
        private readonly INasaService _nasaService;

        public NasaController(INasaService nasaService) 
        {
            _nasaService = nasaService;
        }

        [HttpGet("FotoMarte")]
        public async Task<IActionResult> ClimaMarte([FromBody] MarsPhotos model)
        {
            var resultLista = _nasaService.ListMarsPhotos();
            return Ok();
        }
    }
}
