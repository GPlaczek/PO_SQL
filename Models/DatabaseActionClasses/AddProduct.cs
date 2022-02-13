using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.DatabaseActionClasses
{
    public class AddProduct : IDatabaseAction
    {
        private string Name { get; }
        private string Desc { get; }
        private string Price { get; }
        private string Table { get; }
        public AddProduct(string Name, string Desc, string Price, string Table)
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
            var command = $"INSERT into {Table} (name, desc, price) VALUES ('{Name}', '{Desc}', {Price})";
            SQLiteCommand com = new(command, c1);
            com.ExecuteNonQuery();
            c1.Close();
        }
    }
}
