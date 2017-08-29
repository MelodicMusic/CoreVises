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
        public Product GetProductById(String productId)
        {
            return productData.GetProductById(productId);
        }

        public List<Product> GetProducts()
        {
            return productData.GetProducts();
        }
        public List<Product> getProductsByName(string name)
        {
            return productData.getProductsByName(name);
        }
        public List<Product> getProductsByCategory(string category)
        {
            return productData.getProductsByCategory(category);
        }
        public List<Product> getProductsByPrice(float min, float max)
        {
            return productData.getProductsByPrice(min, max);
        }

    }
}
