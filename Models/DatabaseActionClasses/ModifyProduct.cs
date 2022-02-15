using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace PO_SQL.Models.DatabaseActionClasses
{
    public class ModifyProduct : IDatabaseAction
    {
        private int Id { get; }
        private string Name { get; }
        private string Desc { get; }
        private float Price { get; }
        private string Table { get; }
        public ModifyProduct(int Id, string Name, string Desc, float Price, string Table)
        {
            this.Id = Id;
            this.Name = Name.ToLower();
            this.Desc = Desc.ToLower();
            this.Price = Price;
            this.Table = Table.ToLower();
        }
        public void Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            var command = $"update {Table} set name = '{this.Name}', desc = '{this.Desc}', price = {this.Price} where product_id = {this.Id};";
            Debug.WriteLine(command);
            SQLiteCommand com = new(command, c1);
            com.ExecuteReader();
            c1.Close();
        }
    }
}