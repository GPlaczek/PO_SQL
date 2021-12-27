using System;
using System.Linq;
using System.Threading.Tasks;
using System.collections.Generic;

namespace PO_SQL.Models{
    public struct Product{
        private int Id{ get; }
        private string Name{ get; set; }
        private string Description{ get; set; }
        private int Price{ get; set; }

        public Product(){}
    }
}
