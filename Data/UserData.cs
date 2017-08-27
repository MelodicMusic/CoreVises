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

        public Boolean UpdateUser(string objectId, User user)
        {
            try
            {

                var collection = database.GetCollection<BsonDocument>("user");

                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(objectId));

                collection.ReplaceOne(filter, user.ToBsonDocument());
                return true;
            }
            catch (MongoException ex)
            {
                return false;
            }
        }
        public Boolean DeleteUser(string objectId)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("user");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(objectId));
                collection.DeleteOne(filter);
                return true;
            }
            catch (MongoException ex)
            {
                return false;
            }

        }
        public User SignIn(User user)
        {
            var collection = database.GetCollection<BsonDocument>("user");
            BsonDocument document = user.ToBsonDocument();
            collection.InsertOne(document);
            user._id = document["_id"].AsObjectId;
            return user;

        }
        public User SearchUser(string userId)
        {

            var collection = database.GetCollection<BsonDocument>("user");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(userId));

            var result = collection.Find(filter).FirstOrDefault();

            User user = new User();
            user._id = result["_id"].AsObjectId;
            user.name = result["name"].ToString();
            user.lastName = result["lastName"].ToString();
            user.email = result["email"].ToString();
            user.password = result["password"].ToString();
            user.role = result["role"].ToString();

            return user;

        }

        public User LogIn(string email, string password)
        {
            var collection = database.GetCollection<BsonDocument>("user");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("email", email) & builder.Eq("password", password);

            var result = collection.Find(filter).FirstOrDefault();
            if (result != null)
            {
                User user = new User();
                user.name = result["name"].ToString();
                user.lastName = result["lastName"].ToString();
                user.email = result["email"].ToString();
                user.password = result["password"].ToString();
                user.role = result["role"].ToString();

                return user;
            }
            else
            {
                return null;
            }

        }

        public List<User> GetUsers()
        {
            var collection = database.GetCollection<BsonDocument>("user");
            List<User> users = new List<User>();

            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                User user = new User();
                user._id = document["_id"].AsObjectId;
                user.name = document["name"].ToString();
                user.lastName = document["lastName"].ToString();
                user.email = document["email"].ToString();
                user.password = document["password"].ToString();
                user.role = document["role"].ToString();

                users.Add(user);
            }

            return users;
        }
    }
}
