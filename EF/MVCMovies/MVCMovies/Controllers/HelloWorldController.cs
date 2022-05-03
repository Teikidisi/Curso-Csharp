using Microsoft.AspNetCore.Mvc;
using MVCMovies.Models;
using System.Text;

namespace MVCMovies.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Hello world from the controller";
            ViewData["MyVariable"] = 5;
            //return View("/View/Home/Index.cshtml");
            return View(); //regresa la vista que está ubicada por default en Views/[controlador]/[metodo]

        }
        //GET
        [HttpGet("Welcome/{id}/{name}")]
        public string Welcome(int id, int numTimes = 1)
        {
            var name = Request.Query["name"]; // para no usar inicializadores en el metodo, pero regresa como string
            var myMessage = new StringBuilder();
            for (int i = 0; i < numTimes; i++)
            {
                myMessage.Append($"Welome to MVC {name} with  ID = {id}");
            }
            return myMessage.ToString();
        }

        public IActionResult WelcomeAgain(string name, int id, bool isRed)
        {
            ViewData["Name"] = name;
            ViewData["IsRed"] = isRed;
            ViewData["Id"] = id;
            return View();
        }

        public IActionResult Hello()
        {
            var viewModel = new HelloViewModel();
            viewModel.Name = "Rodro";
            viewModel.NumTimes = 10;
            viewModel.Comments = new List<string>
            {
                "Bienvenidos",
                "Welcome",
                "Wilkommen",
                "ASP.NET CORE",
                "MVC"
            };
            return View(viewModel);
        }
    }
}
