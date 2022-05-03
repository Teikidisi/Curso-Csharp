using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCMovies.Models;

namespace MVCMovies.Pages
{
    [Authorize]
    public class ContactModel : PageModel
    {
        public string Message { get; set; } = "Contact";
        [BindProperty]
        public ContactForm Form { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }

        public void OnGet()
        {
            Message += $" Us in {Category}";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await 

            return RedirectToPage("ContactConfirmation");
        }
        //podemos tener diferentes posts para el mismo page definiendo en el boton de submit la ruta hacia el metodo
        //que se dirigirá usando el helper de asp-page-handler
        public IActionResult OnPostCancelAsync()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
