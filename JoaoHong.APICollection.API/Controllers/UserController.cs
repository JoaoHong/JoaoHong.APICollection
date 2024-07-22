using JoaoHong.APICollection.Domain.Entities;
using JoaoHong.APICollection.Domain.Port.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace JoaoHong.APICollection.API.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("Criar Usuario")]
		public async Task<IActionResult> CriarUsuario([FromBody] Users model) 
		{
			var user = _userService.CreateUser(model);

			return Ok(user);
		}
	}
}
