using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_SQL.Models.DatabaseActionClasses;
using PO_SQL.Models.ActionClasses;
using System.Diagnostics;


namespace PO_SQL.Controllers
{
    public class DatabaseResultsController : Controller
    {
        private IDatabaseAction a1;
        [HttpPost]
        public bool ValidPrice(ref string Price)
        {
            try
            {
                if (int.TryParse(Price, out var result)) return true;
                else if (float.TryParse(Price, out var result2))
                {
                    if (Price.IndexOf(".") >= 0 && Price.Split(".")[1].Length <= 2) return true;
                    else if (Price.IndexOf(",") >= 0 && Price.Split(",")[1].Length <= 2)
                    {
                        string[] Digits;
                        Digits = Price.Split(",");
                        Price = Digits[0] + "." + Digits[1];
                        return true;
                    }
                }
            }
            catch {  }
            return false;
        }
        public IActionResult AddProductResult(string Name, string Desc, string Price, string Table)
        {
            bool success = false;
            if (Table != null)
            {
                success = ValidPrice(ref Price);
            }
            if (success)
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
        public IActionResult DeleteProductResult(int Name, string Table)
        {
            Debug.WriteLine(Name);
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
        [HttpPost]
        public IActionResult ModifyResult(int Name, string Id, string Desc, string Price, string Table)
        {
            bool success = false;
            if(Table != null)
            {
                success = ValidPrice(ref Price);
            }
            if (success)
            {
                a1 = new ModifyProduct(Name, Id, Desc, float.Parse(Price), Table);
                a1.Execute();
                ViewData["stat"] = "Udało się zmodyfikować produkt";
            }
            else
            {
                ViewData["stat"] = "Nie udało się zmodyfikować produktu";
            }
            return View();
        }
    }
}
