using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PO_SQL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PO_SQL.Models.ActionClasses;

namespace PO_SQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchProducts()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult ModifyProduct()
        {
            return View();
        }

        public IActionResult AddTable()
        {
            return View();
        }
        public IActionResult DeleteProduct()
        {
/*            var tabs = Request.Form["Table[]"];
            List<string> Tables = new(tabs);
            var a1 = new SearchTables(productName, productDescription, priceMin, priceMax, Tables);
            ViewData["query"] = a1.Execute();*/
            return View();
        }
        public IActionResult DeleteTable()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
