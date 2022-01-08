using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_SQL.Models.ActionClasses
{
    public class SearchTables : IAction
    {
        private string Name { get; set; }
        private string Desc { get; set; }
        private string PriceMin { get; set; }
        private string PriceMax { get; set; }
        public List<String> Tables;
        public string execute()
        {
            return $"SELECT * FROM {Tables[0]} WHERE name={Name} and desc=*{ Desc}* and price > {PriceMin} and price < {PriceMax}";
        }
        public SearchTables(string Name, string Desc, string min, string max, List<String> Tables)
        {
            this.Name = Name;
            this.Desc = Desc;
            this.PriceMin = min;
            this.PriceMax = max;
            this.Tables = Tables;
        }
    }
}
