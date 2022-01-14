using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace PO_SQL.Models.ActionClasses
{
    public class DeleteTable : IAction
    {
        public string Name { get; set; }
        public DeleteTable(string Name)
        {
            this.Name = Name;
        }
        public SQLiteDataReader Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            var command = $"DROP table {Name}";
            SQLiteCommand com = new(command, c1);
            Console.WriteLine("Udało się");
            return com.ExecuteReader();
        }
    }
}
