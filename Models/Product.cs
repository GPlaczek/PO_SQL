using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PO_SQL.Models{
    public class Product{
        public int Id{ get; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public int Price{ get; set; }

        public Product(){}
    }
}
