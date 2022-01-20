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
        public List<String> Tables;
        public SQLiteDataReader Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            StringBuilder sb = new($"select * FROM {Tables[0]} WHERE name='{Name}' and desc='{Desc}' ");
            for (int i = 1; i < Tables.Count; i++)
            {
                sb.Append($"UNION SELECT * from {Tables[i]} WHERE name='{Name}' and desc='{Desc}'");
            }
            Debug.Write($"SELECT * FROM {sb.ToString()}");
            SQLiteCommand com = new(sb.ToString(), c1);
            return com.ExecuteReader();
        }
        public SearchTables(string Name, string Desc, string min, string max, List<String> Tables)
        {
            this.Name = Name.ToLower();
            this.Desc = Desc.ToLower();
            this.PriceMin = min;
            this.PriceMax = max;
            this.Tables = Tables;
        }
    }
}
