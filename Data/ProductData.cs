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


        public Boolean UpdateProduct(string objectId, Product product)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("product");

                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(objectId));

                product._id = ObjectId.Parse(objectId);

                collection.ReplaceOne(filter, product.ToBsonDocument());
                return true;
            }
            catch (MongoException)
            {
                return false;
            }

        }
        public Boolean DeleteProduct(string objectId)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("product");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(objectId));
                collection.DeleteOne(filter);
                return true;
            }
            catch (MongoException)
            {
                return false;
            }

        }
        public Product InsertProduct(Product product)
        {
            var collection = database.GetCollection<BsonDocument>("product");
            BsonDocument document = product.ToBsonDocument();


            collection.InsertOne(document);

            product._id = document["_id"].AsObjectId;
            return product;

        }
        public Product GetProductById(ObjectId productId)
        {

            var collection = database.GetCollection<BsonDocument>("product");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", productId);

            var result = collection.Find(filter).FirstOrDefault();

            Product product = new Product();
            product._id = result["_id"].AsObjectId;
            product.name = result["name"].ToString();
            product.price = float.Parse(result["price"].ToString());
            product.category = result["category"].ToString();
            product.brand = result["brand"].ToString();
            product.description = result["description"].ToString();
            product.imageUrl = result["url"].ToString();
            return product;
        }

        public List<Product> GetProducts()
        {
            var collection = database.GetCollection<BsonDocument>("product");
            List<Product> products = new List<Product>();

            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                Product product = new Product();
                product._id = document["_id"].AsObjectId;
                product.name = document["name"].ToString();
                product.price = float.Parse(document["price"].ToString());
                product.category = document["category"].ToString();
                product.brand = document["brand"].ToString();
                product.description = document["description"].ToString();
                product.imageUrl = document["url"].ToString();
                products.Add(product);
            }

            return products;
        }

        public List<Product> getProductsByName(string name)
        {
            List<Product> products = new List<Product>();
            var collection = database.GetCollection<BsonDocument>("product");


            // var filter = Builders<BsonDocument>.Filter.Regex("name", name);
            var filter = Builders<BsonDocument>.Filter.Regex("name", new BsonRegularExpression(".*" + name + ".*", "i"));
            var result = collection.Find(filter).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    Product product = new Product();
                    product._id = item["_id"].AsObjectId;
                    product.name = item["name"].ToString();
                    product.price = float.Parse(item["price"].ToString());
                    product.category = item["category"].ToString();
                    product.brand = item["brand"].ToString();
                    product.description = item["description"].ToString();
                    product.imageUrl = item["url"].ToString();
                    products.Add(product);
                }

                return products;
            }
            else
            {
                return null;
            }
        }

        public List<Product> getProductsByCategory(string category)
        {
            List<Product> products = new List<Product>();
            var collection = database.GetCollection<BsonDocument>("product");

            var filter = Builders<BsonDocument>.Filter.Eq("category", category);

            var result = collection.Find(filter).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    Product product = new Product();
                    product._id = item["_id"].AsObjectId;
                    product.name = item["name"].ToString();
                    product.price = float.Parse(item["price"].ToString());
                    product.category = item["category"].ToString();
                    product.brand = item["brand"].ToString();
                    product.description = item["description"].ToString();
                    product.imageUrl = item["url"].ToString();
                    products.Add(product);

                }

                return products;
            }
            else
            {
                return null;
            }

        }

        public List<Product> getProductsByPrice(float min, float max)
        {

            List<Product> products = new List<Product>();
            var collection = database.GetCollection<BsonDocument>("product");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Lt("price", max) & builder.Gt("price", min);

            var result = collection.Find(filter).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    Product product = new Product();
                    product._id = item["_id"].AsObjectId;
                    product.name = item["name"].ToString();
                    product.price = float.Parse(item["price"].ToString());
                    product.category = item["category"].ToString();
                    product.brand = item["brand"].ToString();
                    product.description = item["description"].ToString();
                    product.imageUrl = item["url"].ToString();
                    products.Add(product);

                }

                return products;
            }
            else
            {
                return null;
            }
        }
    }
}
