using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_SQL.Models.ActionClasses;

namespace PO_SQL.Controllers
{
    public class ResultsController : Controller
    {
        private IAction a1;
        [HttpPost]
        public IActionResult SearchResults(string tableName, string productName, string productDescription, string priceMin, string priceMax)
        {
            var tabs = Request.Form["Table[]"];
            List<string> Tables = new(tabs);
            a1 = new SearchTables(productName, productDescription, priceMin, priceMax, Tables);
            ViewData["query"] = a1.Execute();
            return View();
        }
        public IActionResult AddResult(string productName, string productDescription, string price)
        {
            ViewData["ProductName"] = productName;
            ViewData["ProductDescription"] = productDescription;
            ViewData["Price"] = price;
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

    }
}
