using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Warehouse_Manager.Models;

namespace Warehouse_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaseConfiguration _baza;

        public HomeController(ILogger<HomeController> logger, BaseConfiguration baza)
        {
            _logger = logger;
            _baza = baza;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = await _baza.Administratorzy
                    .FirstOrDefaultAsync(a => a.Login == model.Login && a.Haslo == model.Haslo);

                if (admin != null)
                {
                    HttpContext.Session.SetInt32("AdminId", admin.Id);
                    return RedirectToAction("List", "Worker");
                }

                var user = await _baza.Pracownicy
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Haslo == model.Haslo);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return RedirectToAction("List", "Product");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}