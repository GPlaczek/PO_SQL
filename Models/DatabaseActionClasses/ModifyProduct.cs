using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.DatabaseActionClasses
{
    public class ModifyProduct : IDatabaseAction
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Price { get; set; }
        public string Table { get; set; }
        public ModifyProduct(string Name, string Desc, string Price, string Table)
        {
            this.Name = Name.ToLower();
            this.Desc = Desc.ToLower();
            this.Price = Price.ToLower();
            this.Table = Table.ToLower();
        }
        public void Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            var command = $"";
            SQLiteCommand com = new(command, c1);
            com.ExecuteNonQuery();
        }
    }
}
