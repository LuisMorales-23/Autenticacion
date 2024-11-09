using Microsoft.AspNetCore.Mvc;
using Autenticacion.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs;
using Microsoft.Identity.Client;

namespace Autenticacion.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]

        public User user { get; set; }

    public void OnGet()
        {

        }
   
    public async Task <IActionResult> OnPostAsync ()
        {
            if (!ModelState.IsValid) return Page();

            if (user.Email == "correo@gmail.com" && user.Password == "12345")
            {
                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}
