using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.ActionClasses
{
    public class AddTable : IAction
    {
        private string Name { get; }
        private SQLiteConnection c1;
        public AddTable(string Name)
        {
            this.Name = Name.ToLower();
        }
        public SQLiteDataReader Execute()
        {
            c1 = new("Data Source = Data\\database.db");
            c1.Open();
            var command = $"CREATE table {Name} (product_id integer primary key autoincrement, name varchar(32), desc varchar(256), price float)";
            SQLiteCommand com = new(command, c1);
            Console.WriteLine("Udało się");
            return com.ExecuteReader();
        }
        public void CloseConnection()
        {
            c1.Close();
        }
    }
}
