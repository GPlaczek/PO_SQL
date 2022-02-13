﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_SQL.Models.ActionClasses;
using PO_SQL.Models.DatabaseActionClasses;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace PO_SQL.Controllers
{
    public class ResultsController : Controller
    {
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private IAction a1;
        [HttpPost]
        public IActionResult SearchResults(string productName, string productDescription, float? priceMin, float? priceMax)
        {
            var tabs = Request.Form["Table[]"];
            List<string> Tables = new(tabs);
            List<string> tabNames = new();
            List<string> names = new();
            List<string> description = new();
            List<float> price = new();
            foreach (string Table in Tables)
            {
                a1 = new SearchTables(productName, productDescription, priceMin, priceMax, Table);
                var query = a1.Execute();
                while (query.Read())
                {
                    tabNames.Add(Table);
                    names.Add(query.GetString(1));
                    description.Add(query.GetString(2));
                    price.Add(query.GetFloat(3));
                }
                ViewData["tabNames"] = tabNames;
                ViewData["names"] = names;
                ViewData["description"] = description;
                ViewData["price"] = price;
            }
            return View();
        }
        public IActionResult ModifyResult(string productName, string productDescription, string price)
        {
            ViewData["ProductName"] = productName;
            ViewData["ProductDescription"] = productDescription;
            ViewData["Price"] = price;
            return View();
        }
        public IActionResult AddTableResult(string tableName)
        {
            tableName = tableName.ToLower();
            a1 = new AddTable(tableName);
            try
            {
                a1.Execute();
                ViewData["stat"] = $"Udało się utworzyć tabelę {tableName}";
            }
            catch
            {
                ViewData["stat"] = $"Nie udało się utworzyć tabeli {tableName}";
            }
            return View();
        }
        public IActionResult DeleteTableResult(string tableName)
        {
            if (tableName == null)
            {
                ViewData["stat"] = "Brak tabel w bazie danych";
                return View();
            }
            tableName = tableName.ToLower();
            a1 = new DeleteTable(tableName);
            try
            {
                a1.Execute();
                ViewData["stat"] = $"Udało się usunąć tabelę {tableName}";
            }
            catch
            {
                ViewData["stat"] = $"Nie udało się usunąć tabeli {tableName}";
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportTableResultAsync(IFormFile FileName, string TableName)
        {
            if(FileName != null)
            {
                var path = Path.Combine(wwwrootDirectory, FileName.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await FileName.CopyToAsync(stream);
                }
                a1 = new AddTable(TableName);
                a1.Execute();
                StreamReader s1 = new(path);
                var line = s1.ReadLine();
                IDatabaseAction a2;
                try
                {
                    while (line != null)
                    {
                        var spl = line.Split(';');
                        if (spl.Length != 3) throw new InvalidDataException();
                        a2 = new AddProduct(spl[0], spl[1], spl[2], TableName);
                        a2.Execute();
                        line = s1.ReadLine();
                    }
                    ViewData["stat"] = "Udało się zaimportować tabelę";
                }
                catch
                {
                    a1 = new DeleteTable(TableName);
                    a1.Execute();
                    ViewData["stat"] = "Błąd przy wczytywaniu danych";
                    s1.Close();
                }
                s1.Close();
            }
            return View();
        }
    }
}
