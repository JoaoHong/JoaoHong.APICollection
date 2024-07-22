using JoaoHong.APICollection.Domain.Port.InfraStructure;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Infrastructure.Context
{
    public class MySQLContextDB : IMySQLContextDB
    {
        private readonly IConfiguration _configuration;
        private MySqlConnection conn = null;

        public MySQLContextDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		public async Task<MySqlConnection> Connection(string connectionString)
		{
			var conn = new MySqlConnection(_configuration.GetConnectionString(connectionString));

			try
			{
				await conn.OpenAsync();
			}
			catch (Exception ex)
			{
				// Log the exception
				Console.WriteLine($"An error occurred while opening the connection: {ex.Message}");
				// Optionally, rethrow the exception or handle it as needed
				throw;
			}
			return conn;
		}


		public async Task<bool> Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
