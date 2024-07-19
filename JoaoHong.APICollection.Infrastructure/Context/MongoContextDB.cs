using JoaoHong.APICollection.Domain.Port.InfraStructure;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Infrastructure.Context
{
    public class MongoContextDB : IMongoContextDB
    {
        private readonly IConfiguration _configuration;
        private IMongoClient _client;
        private IMongoDatabase _database;
        private string _databaseName;
        private string _collectionName;

        public MongoContextDB(IConfiguration configuration)
        {
            _configuration = configuration;
            Initialize();
        }

        private void Initialize() 
        {
            var connectionString = _configuration.GetConnectionString("MongoAPICollection");
            _client = new MongoClient(connectionString);    
            var mongoUrl = new MongoUrl(connectionString);
            _databaseName = mongoUrl.DatabaseName;
            _collectionName = _configuration["MongoSettings:CollectionName"];
            _database = _client.GetDatabase(_configuration["MongoSettings:CollectionName"]);

        }

        public string CollectionName()
        {
            return _collectionName; 
        }

        public Task<IMongoDatabase> Connection()
        {
            return Task.FromResult(_database);
        }
    }
}
