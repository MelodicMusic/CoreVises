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

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public Product Post([FromBody]Object value)
        {
            /*
            Product p = new Product();
            p.name = "pnombre";
            p.price = 123;
            p.description = "pdesc";
            p.brand = "pmarca";
            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
            */

            Product product = new Product();
            product = JsonConvert.DeserializeObject<Product>(value.ToString());

            return this.productBusiness.Insert(product);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
