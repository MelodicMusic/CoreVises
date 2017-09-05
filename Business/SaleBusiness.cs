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

        public Boolean Update(string objectId, Sale sale)
        {
            return saleData.UpdateSale(objectId, sale);
        }

        public Boolean Delete(string objectId)
        {
            return saleData.DeleteSale(objectId);
        }
        public Sale Insert(Sale sale)
        {
            return saleData.InsertSale(sale);

        }
        public Sale Search(String saleId)
        {
            return saleData.SearchSale(saleId);
        }

        public List<Sale> GetSales()
        {
            return saleData.GetSales();
        }
        public List<Sale> getSalesByClient(string userId)
        {
            return saleData.getSalesByClient(userId);
        }
        public List<Sale> getSalesByProduct(string productId)
        {
            return saleData.getSalesByProduct(productId);
        }
    }
}
