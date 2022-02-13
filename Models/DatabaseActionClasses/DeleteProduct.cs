using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace PO_SQL.Models.DatabaseActionClasses
{
    public class DeleteProduct : IDatabaseAction
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public DeleteProduct(int Id, string Table)
        {
            this.Id = Id;
            this.Table = Table.ToLower();
        }
        public void Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            var command = $"DELETE FROM {this.Table} WHERE product_id={this.Id}";
            SQLiteCommand com = new(command, c1);
            com.ExecuteNonQuery();
        }
    }
}
