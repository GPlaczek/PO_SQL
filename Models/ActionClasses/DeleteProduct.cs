using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.DatabaseActionClasses
{
    public class DeleteProduct : IDatabaseAction
    {
        public string Name { get; set; }
        public string Table { get; set; }
        public DeleteProduct(string Name, string Table)
        {
            this.Name = Name;
            this.Table = Table;
        }
        public void Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            var command = $"DELETE FROM {Table} WHERE Name='{Name}'";
            SQLiteCommand com = new(command, c1);
            com.ExecuteNonQuery();
        }
    }
}
