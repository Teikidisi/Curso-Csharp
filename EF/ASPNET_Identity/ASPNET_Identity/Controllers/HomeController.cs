using ASPNET_Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNET_Identity.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        //Permite brincar la solicitud de autorizacion y puedes acceder aunque no tengas cuenta
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        //El authorize puede ir al nivel del controlador o de la accion
        [Authorize]
        public async  Task<IActionResult> Profile()
        {
            //var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var user = await _userManager.GetUserAsync(User); //Solo obtiene User si tiene [Authorize] de lo contrario es null
            return View(user);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            return View("Profile",user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}