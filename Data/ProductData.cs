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
    public class ProductData
    {
        private IMongoClient client;
        private IMongoDatabase database;

        public ProductData()
        {
            //se establece la cadena de conexión al server
            this.client = new MongoClient("mongodb://danielns:123457@ds145303.mlab.com:45303/shop_melodic_music");
            // base de datos donde se realizarán las operaciones
            this.database = client.GetDatabase("shop_melodic_music");
        }


        public void Update(string objectId, Product product)
        {
            var collection = database.GetCollection<BsonDocument>("product");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(objectId));

            collection.ReplaceOne(filter, product.ToBsonDocument());
        }
        public void Delete(ObjectId objectId)
        {
            var collection = database.GetCollection<BsonDocument>("product");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            collection.DeleteOne(filter);

        }
        public Product Insert(Product product)
        {
            var collection = database.GetCollection<BsonDocument>("product");
            BsonDocument document = product.ToBsonDocument();
            collection.InsertOne(document);
            product._id = document["_id"].AsObjectId;
            return product;

        }
        public Product Search(String productId)
        {
            //Se obtiene la colección deseada de la base de datos
            var collection = database.GetCollection<BsonDocument>("product");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(productId));

            var result = collection.Find(filter).FirstOrDefault();

            Product product = new Product();
            product._id = result["_id"].AsObjectId;
            product.name = result["name"].ToString();
            product.price = float.Parse(result["price"].ToString());
            product.category = result["category"].ToString();
            product.brand = result["brand"].ToString();
            product.description = result["description"].ToString();
            
            return product;
        }
    }
}
