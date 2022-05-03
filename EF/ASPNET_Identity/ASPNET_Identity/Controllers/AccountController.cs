using ASPNET_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPNET_Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login(string returnUrl)
        {
            returnUrl ??= "/";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty,"There's invalid data");
                return View();
            }

            //logica para iniciar sesion
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
            //redirigir si las credenciales son correctas
            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "The user or password is incorrect.");
            
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There's invalid data");
                return View();
            }

            var user = new ApplicationUser(request.Email, request.Name);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, request.Role.ToString());

                if (result.Succeeded)
                    return LocalRedirect("/");
                else
                {
                    await _userManager.DeleteAsync(user);
                    ModelState.AddModelError("", "The account couldn't be created, please try again.");
                }
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/");
        }
    }
}
