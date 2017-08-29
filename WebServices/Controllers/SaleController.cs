using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Domain;
using Newtonsoft.Json;

namespace WebServices.Controllers
{
    public class SaleController : ApiController
    {

        SaleBusiness saleBusiness = new SaleBusiness();

        // GET: api/Sale
        public List<Sale> Get()
        {
            return this.saleBusiness.GetSales();
        }

        // POST: api/Sale
        public Sale Post([FromBody]Object value)
        {
            Sale sale = new Sale();
            sale = JsonConvert.DeserializeObject<Sale>(value.ToString());

            return this.saleBusiness.Insert(sale);
        }

    }
}
