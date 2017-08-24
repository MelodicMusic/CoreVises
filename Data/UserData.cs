using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using Domain;

namespace Data
{
    public class UserData
    {
        private IMongoClient client;
        private IMongoDatabase database;

        public UserData()
        {
            //se establece la cadena de conexión al server
            this.client = new MongoClient("mongodb://danielns:123457@ds145303.mlab.com:45303/shop_melodic_music");
            // base de datos donde se realizarán las operaciones
            this.database = client.GetDatabase("shop_melodic_music");
        }

        public void Update(ObjectId objectId, User user)
        {
            var collection = database.GetCollection<BsonDocument>("user");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);

            collection.ReplaceOne(filter, user.ToBsonDocument());
        }
        public void Delete(ObjectId objectId)
        {
            var collection = database.GetCollection<BsonDocument>("user");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            collection.DeleteOne(filter);

        }
        public User Insert(User user)
        {
            var collection = database.GetCollection<BsonDocument>("user");
            BsonDocument document = user.ToBsonDocument();
            collection.InsertOne(document);
            user._id = document["_id"].AsObjectId;
            return user;

        }
        public User Search(String saleId)
        {
            //Se obtiene la colección deseada de la base de datos
            var collection = database.GetCollection<BsonDocument>("user");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(saleId));

            var result = collection.Find(filter).FirstOrDefault();

            User user = new User();
            user.name = result["name"].ToString();
            user.lastName = result["lastName"].ToString();
            user.email = result["category"].ToString();
            user.password = result["brand"].ToString();
            user.role = result["description"].ToString();

            return user;
            
        }
    }
}
