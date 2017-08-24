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
    public class SaleData
    {
        private IMongoClient client;
        private IMongoDatabase database;

        public SaleData()
        {
            //se establece la cadena de conexión al server
            this.client = new MongoClient("mongodb://danielns:123457@ds145303.mlab.com:45303/shop_melodic_music");
            // base de datos donde se realizarán las operaciones
            this.database = client.GetDatabase("shop_melodic_music");
        }

        public void Update(ObjectId objectId, Sale sale)
        {
            var collection = database.GetCollection<BsonDocument>("sale");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);

            collection.ReplaceOne(filter, sale.ToBsonDocument());
        }
        public void Delete(ObjectId objectId)
        {
            var collection = database.GetCollection<BsonDocument>("sale");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            collection.DeleteOne(filter);

        }
        public Sale Insert(Sale sale)
        {
            var collection = database.GetCollection<BsonDocument>("sale");
            BsonDocument document = sale.ToBsonDocument();
            collection.InsertOne(document);
            sale._id = document["_id"].AsObjectId;
            return sale;

        }
        public Sale Search(String saleId)
        {
            //Se obtiene la colección deseada de la base de datos
            var collection = database.GetCollection<BsonDocument>("sale");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(saleId));

            var result = collection.Find(filter).FirstOrDefault();

            Sale sale = new Sale();
            sale.date = DateTime.Parse(result["date"].ToString());
            sale.userId = result["userId"].ToString();
            sale.productId = result["productId"].ToString();
            sale.detail = result["detail"].ToString();

            return sale;



        }
    }
}
