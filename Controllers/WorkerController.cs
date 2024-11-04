using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Manager.Models;

namespace Warehouse_Manager.Controllers
{
    public class WorkerController : Controller
    {
        private readonly BaseConfiguration _baza;
        public WorkerController(BaseConfiguration baza)
        {
            _baza = baza;
        }

        [HttpGet]
        public IActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorker(WorkerDTO workerDTO)
        {

            if (!ModelState.IsValid)
            {
                return View(workerDTO);
            }


            var pracownik = new Pracownik
            {
                Imie = workerDTO.Imie,
                Nazwisko = workerDTO.Nazwisko,
                Login = workerDTO.Login,
                Haslo = workerDTO.Haslo,
                DataZatrudnienia = DateTime.Now
            };

            await _baza.Pracownicy.AddAsync(pracownik);
            await _baza.SaveChangesAsync();

            return RedirectToAction("List", "Worker");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var produkty = await _baza.Pracownicy.ToListAsync();
            return View(produkty);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pracownik = await _baza.Pracownicy.FindAsync(id);
            return View(pracownik);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Pracownik pracownik)
        {
            var p = await _baza.Pracownicy.FindAsync(pracownik.Id);

            if (p is not null)
            {
                p.Imie = pracownik.Imie;
                p.Nazwisko = pracownik.Nazwisko;
                p.Login = pracownik.Login;
                p.Haslo = pracownik.Haslo;

                await _baza.SaveChangesAsync();
            }

            return RedirectToAction("List", "Worker");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Pracownik pracownik)
        {
            var p = await _baza.Pracownicy.
                AsNoTracking().
                FirstOrDefaultAsync(x => x.Id == pracownik.Id);

            if (p is not null)
            {
                _baza.Pracownicy.Remove(pracownik);
                await _baza.SaveChangesAsync();
            }

            return RedirectToAction("List", "Worker");
        }
    }
}
