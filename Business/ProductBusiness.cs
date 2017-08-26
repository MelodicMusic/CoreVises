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

        public Boolean Update(string objectId, Product product)
        {
            return productData.UpdateProduct(objectId, product);
        }

        public Boolean Delete(string objectId)
        {
            return productData.DeleteProduct(objectId);
        }
        public Product Insert(Product product)
        {
            return productData.InsertProduct(product);

        }
        public Product Search(String productId)
        {
            return productData.SearchProduct(productId);
        }

        public List<Product> GetProducts()
        {
            return productData.GetProducts();
        }

    }
}
