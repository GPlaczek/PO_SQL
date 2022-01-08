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
        public IActionResult SearchResults(string productName, string productDescription, string priceMin, string priceMax)
        {
            a1 = new SearchTables(productName, productDescription, priceMin, priceMax, new List<string>() { "tabela" });
            ViewData["query"] = a1.execute();
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
    }
}
