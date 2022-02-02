using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_SQL.Models.DatabaseActionClasses;
using PO_SQL.Models.ActionClasses;

namespace PO_SQL.Controllers
{
    public class DatabaseResultsController : Controller
    {
        private IDatabaseAction a1;
        [HttpPost]
        public IActionResult AddProductResult(string Name, string Desc, string Price, string Table)
        {
            if (Table != null) 
            {
                a1 = new AddProduct(Name, Desc, Price, Table);
                a1.Execute();
                ViewData["stat"] = "Udało się dodać produkt";
            }
            else
            {
                ViewData["stat"] = "Nie udało się dodać produktu";
            }
            return View();
        }
        public IActionResult DeleteProductResult(string Name, string Table)
        {
            if (Table != null)
            {
                a1 = new DeleteProduct(Name, Table);
                a1.Execute();
                ViewData["stat"] = "Udało się usunąć produkt";
            }
            else
            {
                ViewData["stat"] = "Nie udało się usunąć produktu";
            }
            return View();
        }
    }
}
