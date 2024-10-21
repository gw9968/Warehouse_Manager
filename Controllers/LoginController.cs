using Microsoft.AspNetCore.Mvc;
using Warehouse_Manager.Models;
using System.Collections.Generic;

namespace Warehouse_Manager.Controllers
{
    public class LoginController : Controller
    {
        private static readonly List<UserAccount> _sampleAccounts = new List<UserAccount>
        {
            new UserAccount { Login = "admin", Haslo = "admin123", Role = "Admin" },
            new UserAccount { Login = "prac", Haslo = "prac123", Role = "Pracownik" }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(string login, string haslo)
        {
            var user = _sampleAccounts.Find(u => u.Login == login && u.Haslo == haslo);

            if (user != null)
            {
                HttpContext.Session.SetString("User", user.Login);
                HttpContext.Session.SetString("Role", user.Role);

                if (user.Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else if (user.Role == "Pracownik")
                {
                    return RedirectToAction("Dashboard", "Worker");
                }
            }

            ViewBag.Error = "Nieudana próba logowania";
            return View("Index");
        }
    }

    public class UserAccount
    {
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Role { get; set; }
    }
}
