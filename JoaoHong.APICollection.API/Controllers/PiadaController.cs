using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Port.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace JoaoHong.APICollection.API.Controllers
{
    [ApiController]
	[Route("[controller]")]
	//[Authorize]
	public class PiadaController : ControllerBase
	{
		private readonly IPiadaService _piadaService;

		public PiadaController(IPiadaService piadaService) 
		{
			_piadaService = piadaService;
		}

		[HttpPost("GerarPiada")]
		public async Task<IActionResult> GerarPiada([FromBody] ConsultarPiada model)
		{
			var piada = await _piadaService.FindJoke(model);

			return Ok(piada);
		}
	}
}
