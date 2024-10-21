using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Warehouse_Manager.Models;
using System.Linq;

namespace Warehouse_Manager.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ViewLogs()
        {
            var logs = new List<Log>
            {
                new Log { Id = 1, PracownikId = 1, ProduktId = 101, Akcja = "Dodano produkt", CzasAkcji = DateTime.Now.AddMinutes(-30) },
                new Log { Id = 2, PracownikId = 1, ProduktId = 102, Akcja = "Zaktualizowano produkt", CzasAkcji = DateTime.Now.AddHours(-1) },
                new Log { Id = 3, PracownikId = 2, ProduktId = 103, Akcja = "Usunięto produkt", CzasAkcji = DateTime.Now.AddHours(-2) },
                new Log { Id = 4, PracownikId = 2, ProduktId = 104, Akcja = "Dodano produkt", CzasAkcji = DateTime.Now.AddHours(-3) }
            };

            return View(logs);
        }

        private static List<Pracownik> workers = new List<Pracownik>
        {
            new Pracownik { Id = 1, Imie = "John", Nazwisko = "Doe", Login = "john.doe", Haslo = "password", DataZatrudnienia = new DateTime(2015, 12, 25), Zalogowany = false },
            new Pracownik { Id = 2, Imie = "Jane", Nazwisko = "Smith", Login = "jane.smith", Haslo = "password", DataZatrudnienia = new DateTime(2015, 12, 25), Zalogowany = false }
        };

        public IActionResult ManageWorkers()
        {
            return View(workers);
        }

        [HttpGet]
        public IActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWorker(Pracownik newWorker)
        {
            if (ModelState.IsValid)
            {
                newWorker.Id = workers.Count + 1;
                workers.Add(newWorker);
                return RedirectToAction("ManageWorkers");
            }
            return View(newWorker);
        }

        public IActionResult DeleteWorker(int id)
        {
            var worker = workers.FirstOrDefault(w => w.Id == id);
            if (worker != null)
            {
                workers.Remove(worker);
            }
            return RedirectToAction("ManageWorkers");
        }
    }
}
