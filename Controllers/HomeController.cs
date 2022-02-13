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
                // jakies czary sie tu dzieja
                SQLiteConnection c1 = new("Data Source = Data\\database.db");
                c1.Open();
                var command = $"SELECT * FROM {Table} WHERE product_id={Convert.ToInt32(Name)}";
                SQLiteCommand com = new(command, c1);
                SQLiteDataReader data = com.ExecuteReader();
                data.Read();
                Product product = new(
                    data.GetInt32(0),
                    data.GetString(1),
                    data.GetString(2),
                    data.GetFloat(3),
                    Table
                );
                c1.Close();
                ViewData["Data"] = product;
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
        public IActionResult ExportCSV()
        {
            return View();
        }

        public JsonResult GetProducts(string id)
        {
            Debug.WriteLine(id);
            string tabName = id;
            a1 = new SearchTables(null, null, null, null, tabName);
            var query = a1.Execute();
            Dictionary<int, Dictionary<string, string>> Products = new Dictionary<int, Dictionary<string, string>>();
            while (query.Read())
            {
                Dictionary<string, string> ProductDesc = new Dictionary<string, string>();
                Debug.WriteLine(query.GetString(1));
                ProductDesc.Add("name", query.GetString(1));
                string desc = query.GetString(2);
                ProductDesc.Add("desc", desc.Substring(0,Math.Min(5, desc.Length)));
                ProductDesc.Add("price", query.GetFloat(3).ToString());
                Products.Add(query.GetInt32(0), ProductDesc); // product_id, product_name + part_of_decription + price
            }
            return Json(Products);
        }
    }
}
