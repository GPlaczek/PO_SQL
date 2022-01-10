using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.ActionClasses
{
    public class SearchTables : IAction
    {
        private string Name { get; set; }
        private string Desc { get; set; }
        private string PriceMin { get; set; }
        private string PriceMax { get; set; }
        public List<String> Tables;
        public SQLiteDataReader Execute()
        {
            SQLiteConnection c1 = new("Data Source = ..\\..\\Data\\database.db");
            c1.Open();
            var command = $"SELECT * FROM {Tables[0]} WHERE name={Name} and desc=*{Desc}* and price > {PriceMin} and price < {PriceMax}";
            SQLiteCommand com = new(command, c1);
            return com.ExecuteReader();
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
