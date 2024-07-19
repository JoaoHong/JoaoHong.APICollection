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
    public class MySQLConxtextDB : IMySQLContextDB
    {
        private readonly IConfiguration _configuration;
        private MySqlConnection conn = null;

        public MySQLConxtextDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<MySqlConnection> Connection(string connectionString)
        {
            conn = new MySqlConnection(_configuration.GetConnectionString(connectionString));

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Dispose();
            }
            return conn;
        }

        public async Task<bool> Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
