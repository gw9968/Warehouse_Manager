using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Manager.Models;

namespace Warehouse_Manager.Controllers
{
    public class ProductController : Controller
    {
        private readonly BaseConfiguration _baza;
        public ProductController(BaseConfiguration baza)
        {
            _baza = baza;
        }

        [HttpGet]
        public async Task<IActionResult> Logs()
        {
            var logi = await _baza.Logi.ToListAsync();
            return View(logi);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(productDTO);
            }

            var produkt = new Produkt
            {
                Nazwa = productDTO.Nazwa,
                Cena = productDTO.Cena,
                Ilosc = productDTO.Ilosc,
                Kategoria = productDTO.Kategoria,
            };

            await _baza.Produkty.AddAsync(produkt);
            await _baza.SaveChangesAsync();

            var logi = new Log
            {
                PracownikId = 1,
                ProduktId = produkt.Id,
                Akcja = "Utworzono",
                CzasAkcji = DateTime.Now,
            };

            await _baza.Logi.AddAsync(logi);  
            await _baza.SaveChangesAsync();

            return RedirectToAction("List", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var produkty = await _baza.Produkty.ToListAsync();
            return View(produkty);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var produkt = await _baza.Produkty.FindAsync(id);
            return View(produkt);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Produkt produkt)
        {
            var p = await _baza.Produkty.FindAsync(produkt.Id);

            if (p is not null)
            {
                p.Nazwa = produkt.Nazwa;
                p.Cena = produkt.Cena;
                p.Ilosc = produkt.Ilosc;
                p.Kategoria = produkt.Kategoria;

                await _baza.SaveChangesAsync();

                var logi = new Log
                {
                    PracownikId = 1,
                    ProduktId = p.Id, 
                    Akcja = "Zmodyfikowano",
                    CzasAkcji = DateTime.Now,
                };

              
                await _baza.Logi.AddAsync(logi);
                await _baza.SaveChangesAsync();
            }

            return RedirectToAction("List", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Produkt produkt)
        {
            var p = await _baza.Produkty.
                AsNoTracking().
                FirstOrDefaultAsync(x => x.Id == produkt.Id);

            if (p is not null)
            {
                _baza.Produkty.Remove(produkt);
                await _baza.SaveChangesAsync();
            }

            return RedirectToAction("List", "Product");
        }
    
    }
}
