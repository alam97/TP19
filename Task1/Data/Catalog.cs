using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Catalog
    {
        private string productName { get; set; }
        private double productPrice { get; set; }
        private int productId { get; set; }

        public Catalog(string name, double price, int id)
        {
            this.productName = name;
            this.productPrice = price;
            this.productId = id;
        }

        public override bool Equals(object obj)
        {
            Catalog compare = (Catalog)obj;
            return this.productId == compare.productId;
        }

        public string ProductName { get => productName; set => productName = value; }
        public double ProductPrice { get => productPrice; set => productPrice = value; }
        public int ProductID { get => productId; set => productId = value; }
    }
}
