using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PO_SQL.Models;
using System.Data.SQLite;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PO_SQL.Models.ActionClasses;
using System.Data.SQLite;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PO_SQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAction a1;

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
        
        public IActionResult ChooseProduct()
        {
            return View();
        }
        
        public IActionResult ModifyProduct(string Name, string Table)
        {
            if (Table != null)
            {
                IAction a1 = new SearchTables(Name, null, null, null, Table);
                SQLiteDataReader data = a1.Execute();
                if (data.Read())
                {
                    Product product = new(
                        data.GetInt32(0),
                        data.GetString(1),
                        data.GetString(2),
                        data.GetFloat(3),
                        Table
                    );
                    ViewData["Data"] = product;
                }
                ViewData["Table"] = Table;
            }
            return View();
        }

        public IActionResult AddTable()
        {
            return View();
        }
        public IActionResult DeleteProduct()
        {
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

        public IActionResult ImportCSV()
        {
            return View();
        }

        public JsonResult GetProducts(string id)
        {
            Debug.WriteLine(id);
            string tabName = id;
            a1 = new SearchTables(null, null, null, null, tabName);
            var query = a1.Execute();
            Dictionary<float, string> Products = new Dictionary<float, string>();
            while (query.Read())
            {
                Debug.WriteLine(query.GetString(1));
                Products.Add(query.GetFloat(0), query.GetString(1)); // product_id, product_name
            }
            return Json(Products);
        }
    }
}
