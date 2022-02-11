using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Text;
using System.Diagnostics;

namespace PO_SQL.Models.ActionClasses
{
    public class SearchTables : IAction
    {
        private string Name { get; set; }
        private string Desc { get; set; }
        private string PriceMin { get; set; }
        private string PriceMax { get; set; }
        private string Table { get; set; }
        public SQLiteDataReader Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            StringBuilder sb = new("");
            sb.Append($"select name, desc, price FROM {Table} WHERE desc LIKE '%{Desc}%' ");
            if (Name != "") sb.Append($"and Name = '{this.Name}' ");
            if (PriceMin != null) sb.Append($"and Price >= {this.PriceMin} ");
            if (PriceMax != null) sb.Append($"and Price <= {this.PriceMax} ");
            Debug.WriteLine($"SELECT * FROM {sb.ToString()}");
            SQLiteCommand com = new(sb.ToString(), c1);
            return com.ExecuteReader();
        }
        public SearchTables(string Name, string Desc, string min, string max, string Table)
        {
            if (Name == null) this.Name = "";
            else this.Name = Name.ToLower();
            if (Desc == null) this.Desc = ""; // pole 'opis' mozna zostawic puste
            else this.Desc = Desc.ToLower();
            if (min == null) min = "0";
            else this.PriceMin = min;   // puste pola zakresu ceny oznaczaja ze cena moze byc dowolna
            if (max == null) max = "1000000000";
            else this.PriceMax = max;
            this.Table = Table;
        }
    }
}
