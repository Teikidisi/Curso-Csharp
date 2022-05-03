using Microsoft.AspNetCore.Mvc;

namespace eShopWeb.Controllers
{
    public class AdminController : Controller
    {

        //- Mostrar en /admin/- todo lo que tenga que ver con crud de productos, proveedores y ordenes de compra
        //- Los cambios de status que sean por ajax

        public IActionResult Index()
        {
            return View();
        }
    }
}
