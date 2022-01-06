using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_SQL.Controllers
{
    public class DifferentController : Controller
    {
        [HttpPost]
        public IActionResult Another(string productName, string productDescription, string priceMin, string priceMax)
        {
            ViewData["ProductName"] = productName;
            ViewData["ProductDescription"] = productDescription;
            ViewData["PriceMin"] = priceMin;
            ViewData["PriceMax"] = priceMax;
            return View();
        }
    }
}
