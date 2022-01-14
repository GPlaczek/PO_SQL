using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_SQL.Models.DatabaseActionClasses;

namespace PO_SQL.Controllers
{
    public class DatabaseResultsController : Controller
    {
        private IDatabaseAction a1;
        public IActionResult AddProductResult(string Name, string Desc, string Price, string Table)
        {
            a1 = new AddProduct(Name, Desc, Price, Table);
            try
            {
                a1.Execute();
                ViewData["stat"] = "Udało się utworzyć produkt";
            }
            catch
            {
                ViewData["stat"] = "Nie udało się utworzyć produktu";
            }
            return View();
        }
        public IActionResult DeleteProductResult(string Name, string Table)
        {
            a1 = new DeleteProduct(Name, Table);
            try
            {
                a1.Execute();
                ViewData["stat"] = "Udało się usunąć produkt";
            }
            catch
            {
                ViewData["stat"] = "Nie udało się usunąć produktu";
            }
            return View();
        }
    }
}
