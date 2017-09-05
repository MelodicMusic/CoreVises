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

        public Boolean UpdateSale(string objectId, Sale sale)
        {
            try
            {

                var collection = database.GetCollection<BsonDocument>("sale");

                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(objectId));

                collection.ReplaceOne(filter, sale.ToBsonDocument());
                return true;
            }
            catch (MongoException)
            {
                return false;
            }
        }
        public Boolean DeleteSale(string objectId)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("sale");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(objectId));
                collection.DeleteOne(filter);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public Sale InsertSale(Sale sale)
        {
            var collection = database.GetCollection<BsonDocument>("sale");
            BsonDocument document = sale.ToBsonDocument();
            collection.InsertOne(document);
            sale._id = document["_id"].AsObjectId;
            return sale;

        }
        public Sale SearchSale(string saleId)
        {

            var collection = database.GetCollection<BsonDocument>("sale");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(saleId));

            var result = collection.Find(filter).FirstOrDefault();

            Sale sale = new Sale();
            sale._id = result["_id"].AsObjectId;
            sale.date = DateTime.Parse(result["date"].ToString());
            sale.userId = result["userId"].ToString();
            sale.productId = result["productId"].ToString();
            sale.detail = result["detail"].ToString();

            return sale;

        }
        public List<Sale> GetSales()
        {
            var collection = database.GetCollection<BsonDocument>("sale");
            List<Sale> sales = new List<Sale>();

            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                Sale sale = new Sale();
                sale._id = document["_id"].AsObjectId;
                sale.date = DateTime.Parse(document["date"].ToString());
                sale.userId = document["userId"].ToString();
                sale.productId = document["productId"].ToString();
                sale.detail = document["detail"].ToString();

                sales.Add(sale);
            }

            return sales;
        }

        public List<Sale> getSalesByClient(string userId)
        {
            List<Sale> sales = new List<Sale>();
            var collection = database.GetCollection<BsonDocument>("sale");
            var filter = Builders<BsonDocument>.Filter.Eq("userId", userId);
            var result = collection.Find(filter).ToList();

            if (result != null)
            {
                foreach (var document in result)
                {
                    Sale sale = new Sale();
                    sale._id = document["_id"].ToString();
                    sale.date = DateTime.Parse(document["date"].ToString());
                    sale.userId = document["userId"].ToString();
                    sale.productId = document["productId"].ToString();
                    sale.detail = document["detail"].ToString();

                    sales.Add(sale);
                }

                return sales;
            }
            else
            {
                return null;
            }
        }


        public List<Sale> getSalesByProduct(string productId)
        {
            List<Sale> sales = new List<Sale>();
            var collection = database.GetCollection<BsonDocument>("sale");
            var filter = Builders<BsonDocument>.Filter.Eq("productId", productId);
            var result = collection.Find(filter).ToList();

            if (result != null)
            {
                foreach (var document in result)
                {
                    Sale sale = new Sale();
                    sale._id = document["_id"].ToString();
                    sale.date = DateTime.Parse(document["date"].ToString());
                    sale.userId = document["userId"].ToString();
                    sale.productId = document["productId"].ToString();
                    sale.detail = document["detail"].ToString();

                    sales.Add(sale);
                }

                return sales;
            }
            else
            {
                return null;
            }
        }


    }
}
