using MongoDB.Bson;

namespace JoaoHong.APICollection.Domain.Entities
{
    public class APILogger
    {
        public ObjectId _id {  get; set; }
        public string stackTrace { get; set; }
        public string erroMessage { get; set; }
        public string user {  get; set; }
        public APILogger() 
        { 
            _id = new ObjectId();
        }
    }
}
