using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Entities;
using JoaoHong.APICollection.Domain.Port.Application;
using JoaoHong.APICollection.Domain.Port.Application.Services;
using System.Security.Cryptography;
using System.Text;

namespace JoaoHong.APICollection.Application.Service.Services
{
    public class UserService : IUserService
	{
		private readonly IEncryptionService _encryptionService;
		public UserService(IEncryptionService encryptionService) 
		{
			_encryptionService = encryptionService;
		}
		public async Task<GenericResponse> CreateUser(Users model)
		{
			try
			{
				model.Senha = await HashPassword(model.Senha);

				
			}
			catch (Exception ex)
			{

			}
		}

		public async Task<string> HashPassword(string password) 
		{
			var hashPassword = await _encryptionService.Encrypt(password);

			return hashPassword;
		}

		public async Task InsertUser(Users model)
		{

		}
	}
}
