using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sale
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public DateTime date { get; set; }
        public string userId { get; set; }
        public string productId { get; set; }
        public string detail { get; set; }

    }
}
