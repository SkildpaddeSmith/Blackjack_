using Blackjack.Models;
using Blackjack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blackjack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NextPage(LoginModel user)
        {
            if (user != null)
            {
                return View("Worksheet", user);
            }
            else
            {
                return PartialView();
            }
        }

        public IActionResult ProcessLogin(LoginModel userModel)
        {
            SecurityServices securityService = new SecurityServices();

            if (securityService.IsValid(userModel))
            {
                return View("Game", userModel);
            }
            else
            {
                return PartialView("InvalidCredentials", userModel);
            }

        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult CreateUser(LoginModel userModel)
        {
            SecurityServices securityService = new SecurityServices();

            if (securityService.UniqueUser(userModel) && securityService.PasswordMatch(userModel))
            {
                return View("Game", userModel);
            }
            else if (securityService.PasswordMatch(userModel) == false)
            {
                return PartialView("InvalidCredentials");
            }
            else
            {
                return View("Error", userModel);
            }
        }
    }
}