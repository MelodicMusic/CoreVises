using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Product
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string category { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
    }
}
