using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Domain.Port.Application
{
	public interface IEncryptionService
	{
		Task<string> Encrypt(string password);
		Task<string> Decrypt(string encryptedPassword);
	}
}
