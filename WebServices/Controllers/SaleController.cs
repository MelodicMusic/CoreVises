using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Domain;
using Newtonsoft.Json;
using WebServices.Security;

namespace WebServices.Controllers
{
    public class SaleController : ApiController
    {

        SaleBusiness saleBusiness = new SaleBusiness();
        DES des = new DES();

        // GET: api/Sale
        public List<Sale> Get()
        {
            return this.saleBusiness.GetSales();
        }

        // POST: api/Sale
        public Sale Post([FromBody]Object value)
        {
            Sale sale = new Sale();
            
            string jsonString = des.Decrypt(value.ToString());
            sale = JsonConvert.DeserializeObject<Sale>(jsonString);

            return this.saleBusiness.Insert(sale);
        }

    }
}
