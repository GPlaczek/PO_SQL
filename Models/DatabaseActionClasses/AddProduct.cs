using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.DatabaseActionClasses
{
    public class AddProduct : IDatabaseAction
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Price { get; set; }
        public string Table { get; set; }
        public AddProduct(string Name, string Desc, string Price, string Table)
        {
            this.Name = Name;
            this.Desc = Desc;
            this.Price = Price;
            this.Table = Table;
        }
        public void Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            var command = $"INSERT into {Table} (name, desc, price) VALUES ('{Name}', '{Desc}', {Price})";
            SQLiteCommand com = new(command, c1);
            com.ExecuteNonQuery();
        }
    }
}
