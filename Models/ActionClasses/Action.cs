using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PO_SQL.Models.ActionClasses
{
    public interface IAction
    {
        public SQLiteDataReader Execute();
    }
}
