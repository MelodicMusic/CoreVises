using Data;
using Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SaleBusiness
    {
        private SaleData saleData = new SaleData();

        public void Update(ObjectId objectId, Sale sale)
        {
            saleData.Update(objectId, sale);
        }

        public void Delete(ObjectId objectId)
        {
            saleData.Delete(objectId);
        }
        public Sale Insert(Sale sale)
        {
            return saleData.Insert(sale);

        }
        public Sale Search(String saleId)
        {
            return saleData.Search(saleId);
        }
    }
}
