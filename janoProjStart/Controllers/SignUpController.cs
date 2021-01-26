using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using janoProjStart.Models;

namespace janoProjStart.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(ILogger<SignUpController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            DatabaseCon z = new DatabaseCon();
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(LoginData a)
        {
            DatabaseCon z = new DatabaseCon();
            z.InsertUsers(a.name, a.email, a.password);

            return Redirect("/");
        }
    }
}
