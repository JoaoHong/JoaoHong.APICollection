using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Port.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoaoHong.APICollection.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NasaController : ControllerBase
    {
        private readonly INasaService _nasaService;

        public NasaController(INasaService nasaService) 
        {
            _nasaService = nasaService;
        }

        [HttpPost("FotoMarte")]
        public async Task<IActionResult> ClimaMarte([FromBody] MarsPhotos model)
        {
            var resultLista = await _nasaService.ListMarsPhotos();
            return Ok();
        }
    }
}
