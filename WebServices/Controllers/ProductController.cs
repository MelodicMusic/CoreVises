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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/id
        public Product Get(string id)
        {
            Product product = new Product();
            product = this.productBusiness.Search(id);

            return product;
        }

        // POST: api/Product
        public Product Post([FromBody]Object value)
        {
            Product product = new Product();
            product = JsonConvert.DeserializeObject<Product>(value.ToString());

            return this.productBusiness.Insert(product);
        }

        // PUT: api/Product/5
        public void Put(string id, [FromBody]Object value)
        {
            Product product = new Product();
            this.productBusiness.Update("", product);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
