using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using arhitektura_projekat.Models;
using Microsoft.AspNetCore.Identity;

namespace arhitektura_projekat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string message)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                ViewBag.FirstName = user?.FirstName;
            }
            if (message == "auth_required")
            {
                TempData["Message"] = "Morate biti prijavljeni da biste pristupili ovoj stranici!";
            }
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                } else
                {
                    TempData["LoginError"] = "Email ili lozinka nisu ispravni. Pokušajte ponovo.";
                    return RedirectToAction("Index", "Home");
                }
                
            }

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
