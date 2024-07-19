using JoaoHong.APICollection.Domain.Entities;
using JoaoHong.APICollection.Domain.Port.InfraStructure;
using JoaoHong.APICollection.Domain.Port.InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Infrastructure.Repository.Repositories
{
    public class ApplicationLoggerRepository : MongoCommandRepository<APILogger>, IApplicationLogger
    {
        public ApplicationLoggerRepository(IMongoContextDB mongoContextDB) : base(mongoContextDB)
        {
        }
    }
}
