using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Business;
using Newtonsoft.Json;

namespace WebServices.Controllers
{
    public class ProductController : ApiController
    {
        ProductBusiness productBusiness = new ProductBusiness();

        // GET: api/Product
        public List<Product> Get()
        {
            return this.productBusiness.GetProducts();
        }

        // GET: api/Product/id
        public Product Get(string id)
        {
            Product product = new Product();
            product = this.productBusiness.Search(id);

            return product;
        }
        

        // GET: api/Product/getProductsByName/value
        [HttpGet]
        [Route("api/Product/getProductsByName/{value}")]
        public List<Product> getProductsByName(string value)
        {
            return this.productBusiness.getProductsByName(value);
        }


        // GET: api/Product/getProductsByCategory/value
        [HttpGet]
        [Route("api/Product/getProductsByCategory/{value}")]
        public List<Product> getProductsByCategory(string value)
        {
            //return value.ToString();
            return this.productBusiness.getProductsByCategory(value);
        }


        // POST: api/Product
        public Product Post([FromBody]Object value)
        {
            Product product = new Product();
            product = JsonConvert.DeserializeObject<Product>(value.ToString());

            return this.productBusiness.Insert(product);
        }

        // PUT: api/Product/value
        public Boolean Put(string id, [FromBody]Object value)
        {
            Product product = new Product();
            product = JsonConvert.DeserializeObject<Product>(value.ToString());

            return this.productBusiness.Update(id, product); ;
        }

        // DELETE: api/Product/value
        public Boolean Delete(string id)
        {
            return this.productBusiness.Delete(id);
        }
    }
}
