using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Domain.Port.InfraStructure
{
    public interface IMongoContextDB
    {
        Task<IMongoDatabase> Connection();
        string CollectionName();
    }
}
