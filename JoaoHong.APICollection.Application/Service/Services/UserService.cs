using JoaoHong.APICollection.Domain.DTO;
using JoaoHong.APICollection.Domain.Entities;
using JoaoHong.APICollection.Domain.Port.Application;
using JoaoHong.APICollection.Domain.Port.Application.Services;
using JoaoHong.APICollection.Domain.Port.InfraStructure.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace JoaoHong.APICollection.Application.Service.Services
{
    public class UserService : IUserService
	{
		private readonly IEncryptionService _encryptionService;
		private readonly IUsersRepository _usersRepository;
		public UserService(IEncryptionService encryptionService, IUsersRepository usersRepository) 
		{
			_encryptionService = encryptionService;
			_usersRepository = usersRepository;
		}
		public async Task<GenericResponse> CreateUser(Users model)
		{
			try
			{
				model.Senha = await HashPassword(model.Senha);

				var success = await _usersRepository.InsertAsync(model);

				var response = new GenericResponse();

				response.Title = $"O usuario {model.Nome} foi criado com sucesso";
				response.Description = $"O usuario foi criado com sucesso";

				return response;

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<string> HashPassword(string password) 
		{
			var hashPassword = await _encryptionService.Encrypt(password);

			return hashPassword;
		}
	}
}
