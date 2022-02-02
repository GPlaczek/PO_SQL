﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Text;
using System.Diagnostics;

namespace PO_SQL.Models.ActionClasses
{
    public class SearchTables : IAction
    {
        private string Name { get; set; }
        private string Desc { get; set; }
        private string PriceMin { get; set; }
        private string PriceMax { get; set; }
        public List<String> Tables;
        public SQLiteDataReader Execute()
        {
            SQLiteConnection c1 = new("Data Source = Data\\database.db");
            c1.Open();
            StringBuilder sb = new($"select * FROM {Tables[0]} WHERE name='{Name}' and desc LIKE '%{Desc}%' "); // % - wiele lub 0 znakow
            for (int i = 1; i < Tables.Count; i++)
            {
                sb.Append($"UNION SELECT * from {Tables[i]} WHERE name='{Name}' and desc LIKE '%{Desc}%'");
            }
            Debug.Write($"SELECT * FROM {sb.ToString()}");
            SQLiteCommand com = new(sb.ToString(), c1);
            return com.ExecuteReader();
        }
        public SearchTables(string Name, string Desc, string min, string max, List<String> Tables)
        {
            this.Name = Name.ToLower();
            if (Desc == null) this.Desc = ""; // pole 'opis' mozna zostawic puste
            else this.Desc = Desc.ToLower();
            if (min == null) min = "0";
            else this.PriceMin = min;   // puste pola zakresu ceny oznaczaja ze cena moze byc dowolna
            if (max == null) max = "1000000000";
            else this.PriceMax = max;
            this.Tables = Tables;
        }
    }
}
