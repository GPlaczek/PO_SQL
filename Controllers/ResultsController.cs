using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_SQL.Controllers
{
    public class ResultsController : Controller
    {
        [HttpPost]
        public IActionResult SearchResult(string productName, string productDescription, string priceMin, string priceMax)
        {
            ViewData["ProductName"] = productName;
            ViewData["ProductDescription"] = productDescription;
            ViewData["PriceMin"] = priceMin;
            ViewData["PriceMax"] = priceMax;
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
