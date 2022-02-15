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
        private string Name { get; }
        private SQLiteConnection c1;
        public DeleteTable(string Name)
        {
            this.Name = Name.ToLower();
        }
        public SQLiteDataReader Execute()
        {
            c1 = new("Data Source = Data\\database.db");
            c1.Open();
            var command = $"DROP table {Name}";
            SQLiteCommand com = new(command, c1);
            return com.ExecuteReader();
        }
        public void CloseConnection()
        {
            c1.Close();
        }
    }
}
