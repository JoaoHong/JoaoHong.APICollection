using JoaoHong.APICollection.Domain.Port.Application;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace JoaoHong.APICollection.Application.Service
{
	public class EncryptionService : IEncryptionService
	{
		private readonly IConfiguration _configuration;
		public EncryptionService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<string> Encrypt(string password)
		{
			using (var aes = Aes.Create())
			{
				using (var sha256 = SHA256.Create())
				{
					aes.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(_configuration["Encryption:Key"]));
				}

				aes.GenerateIV();
				var iv = aes.IV;

				using (var encryptor = aes.CreateEncryptor(aes.Key, iv))
				using (var ms = new MemoryStream())
				{
					ms.Write(iv, 0, iv.Length);
					using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					using (var sw = new StreamWriter(cs))
					{
						sw.Write(password);
					}

					return Convert.ToBase64String(ms.ToArray());
				}
			}
		}

		public async Task<string> Decrypt(string encryptedPassword)
		{
			var fullCipher = Convert.FromBase64String(encryptedPassword);

			using (var aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(_configuration["Encryption:Key"]);
				var iv = new byte[aes.BlockSize / 8];
				var cipherBytes = new byte[fullCipher.Length - iv.Length];

				Array.Copy(fullCipher, iv, iv.Length);
				Array.Copy(fullCipher, iv.Length, cipherBytes, 0, cipherBytes.Length);

				using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
				using (var ms = new MemoryStream(cipherBytes))
				using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
				using (var sr = new StreamReader(cs))
				{
					return sr.ReadToEnd();
				}
			}
		}
	}
}
