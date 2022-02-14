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
        private string Name { get; }
        private string Desc { get; }
        private float? PriceMin { get; }
        private float? PriceMax { get; }
        private string Table { get; }

        private SQLiteConnection c1;
        public SQLiteDataReader Execute()
        {
            c1 = new("Data Source = Data\\database.db");
            c1.Open();
            StringBuilder sb = new($"select * FROM {Table} WHERE desc LIKE '%{Desc}%' ");
            if (Name != "") sb.Append($"and Name LIKE '%{this.Name}%' ");
            if (PriceMin != null) sb.Append($"and Price >= {this.PriceMin} ");
            if (PriceMax != null) sb.Append($"and Price <= {this.PriceMax} ");
            SQLiteCommand com = new(sb.ToString(), c1);
            return com.ExecuteReader();
        }
        public SearchTables(string Name, string Desc, float? min, float? max, string Table)
        {
            if (Name == null) this.Name = "";
            else this.Name = Name.ToLower();
            if (Desc == null) this.Desc = ""; // pole 'opis' mozna zostawic puste
            else this.Desc = Desc.ToLower();
            if (min == null) this.PriceMin = 0;
            else this.PriceMin = min;   // puste pola zakresu ceny oznaczaja ze cena moze byc dowolna
            if (max == null) this.PriceMax = 1000000000;
            else this.PriceMax = max;
            this.Table = Table;
        }
        public void CloseConnection()
        {
            c1.Close();
        }
    }
}
