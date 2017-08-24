using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;
using MongoDB.Bson;

namespace Business
{
    public class ProductBusiness
    {
        private ProductData productData = new ProductData();

        public void Update(ObjectId objectId, Product product)
        {
            productData.Update(objectId, product);
        }

        public void Delete(ObjectId objectId)
        {
            productData.Delete(objectId);
        }
        public Product Insert(Product product)
        {
            return productData.Insert(product);

        }
        public Product Search(String productId)
        {
            return productData.Search(productId);
        }
    }
}
