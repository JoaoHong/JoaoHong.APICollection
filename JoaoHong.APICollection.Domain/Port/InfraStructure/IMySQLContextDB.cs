using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Domain.Port.InfraStructure
{
    public interface IMySQLContextDB
    {
        Task<MySqlConnection> Connection(string connectionString);
        Task<bool> Dispose();   
    }
}
