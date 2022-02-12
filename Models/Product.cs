using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PO_SQL.Models{
    public class Product{
        public int Id{ get; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public double Price{ get; set; }
        public string Table { get; set; }

        public Product(){}

        public Product(int Id, string Name, string Description, double Price, string Table)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Table = Table;
        }
    }
}
