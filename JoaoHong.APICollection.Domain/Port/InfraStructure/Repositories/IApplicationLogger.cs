using JoaoHong.APICollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Domain.Port.InfraStructure.Repositories
{
    public interface IApplicationLogger : IMongoCommandRepository<APILogger>
    {
    }
}
