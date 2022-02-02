using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.DatabaseActionClasses
{
    // planuje uzyc tego pozniej aby to dropdownlisty przy usuwaniu produktu
    public class ListProducts : IDatabaseAction
    {
        private string Name { get; set; }
        public void Execute()
        {
            SQLiteConnection c1 = new("Data source = Data\\database.db");
            c1.Open();
            var command = $"SELECT * FROM {Name}";
            SQLiteCommand com = new(command, c1);
            com.ExecuteReader();
        }
    }
}

