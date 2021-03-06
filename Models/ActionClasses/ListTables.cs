using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.ActionClasses
{
    public class ListTables :  IAction
    {
        private SQLiteConnection c1;
        public SQLiteDataReader Execute()
        {
            c1 = new("Data source = Data\\database.db");
            c1.Open();
            var command = $"SELECT name FROM sqlite_master where type = 'table' AND name <> 'sqlite_sequence'";
            SQLiteCommand com = new(command, c1);
            return com.ExecuteReader();
        }

        public void CloseConnection()
        {
            c1.Close();
        }
    }
}
