using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using janoProjStart.Models;
namespace janoProjStart.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginData a = new LoginData();
            return View(a);
        }

        [HttpPost]
        public IActionResult Login(LoginData a)
        {
            DatabaseCon z = new DatabaseCon();
            LoginData b = z.getUser(a.email, a.password);
            if(b == null)
            {
                
                ViewBag.Message = "error wrong username/or passwrod";
                return View("~/Views/Login/Login.cshtml");
            }
            ViewBag.Message = b.name;
            return View("~/Views/Home/index.cshtml");
        }
    }
}
