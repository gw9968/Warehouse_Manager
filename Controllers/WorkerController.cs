using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Warehouse_Manager.Models;
using System.Linq;

namespace Warehouse_Manager.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        private static List<Produkt> products = new List<Produkt>
        {
            new Produkt { Id = 1, Nazwa = "Product A", Cena = 100.0m, Ilosc = 10, Kategoria = "Category 1" },
            new Produkt { Id = 2, Nazwa = "Product B", Cena = 150.0m, Ilosc = 20, Kategoria = "Category 2" }
        };

        public IActionResult ManageProducts()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Produkt newProduct)
        {
            if (ModelState.IsValid)
            {
                newProduct.Id = products.Count + 1;
                products.Add(newProduct);
                return RedirectToAction("ManageProducts");
            }
            return View(newProduct);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("ManageProducts");
        }
    }
}
