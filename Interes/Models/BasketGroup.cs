using DBMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interes.Models
{
    public class BasketGroup
    {
        List<Record> Basket = new List<Record>();
        public IEnumerable<Record> Records{ get { return Basket; }  }
       
        public void AddRecord(Product product, int quantity)
        {
            Record rec = Basket.Where(b => b.Product.Id == product.Id).FirstOrDefault();
            if (rec == null)
            {
                Basket.Add(new Record { Product = product, Quantity = quantity });
            }
            else
            {
                rec.Quantity = rec.Quantity + quantity;
            }
        }
        public void RemoveRecord(Product product)
        {
            Basket.RemoveAll(b=>b.Product.Id==product.Id);
        }
        public void UpdateRecord(Product product, int quantity)
        {
            foreach(var item in Basket)
            {
                if (item.Product.Id == product.Id) item.Quantity = quantity;
            }
        }
        public double BasketTotal()
        {
            return Basket.Sum(r=>Convert.ToDouble(r.Product.PortionPrice)*r.Quantity);
        }
        public int ItemsTotal()
        {
            if (Basket == null) { return 0; }
            else { return Basket.Sum(r => r.Quantity); }
        }
        public void ClearBasket()
        {
            Basket.Clear();
        }
    }
    public class Record
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Record()
        {
            Product = new Product();
            Quantity = 0;
        }
    }
}