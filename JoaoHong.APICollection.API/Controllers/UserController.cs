using JoaoHong.APICollection.Domain.DTO;
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

		[HttpPost("CreateUser")]
		public async Task<IActionResult> CreateUser([FromBody] Users model) 
		{
			var insertUserResponse = await _userService.CreateUser(model);

			return Ok(insertUserResponse);
		}
	}
}
