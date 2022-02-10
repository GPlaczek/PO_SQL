using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.ActionClasses
{
    public class ListProducts : IAction
    {
        private string Name { get; set; }
        public ListProducts(string N)
        {
            this.Name = N;
        }
        public SQLiteDataReader Execute()
        {
            SQLiteConnection c1 = new("Data source = Data\\database.db");
            c1.Open();
            var command = $"SELECT * FROM {Name}";
            SQLiteCommand com = new(command, c1);
            return com.ExecuteReader();
        }
    }
}

