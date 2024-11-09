using Microsoft.AspNetCore.Mvc;
using Autenticacion.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs;
using Microsoft.Identity.Client;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

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
                //se crea los claim, datos a almacenar en la cookie
                var claims = new List<Claim>
                { 
                    new Claim (ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email,user.Email),
                };

                //se asocia a los claims creados a un nombre de una cokkie 
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                //Se agrega la  identidad creada al claimsprincipal de la aplicacion 
               ClaimsPrincipal claimsprincipal =new ClaimsPrincipal(identity);

                //se registra exitosamente la autenticacion y se crea la cookie en el navegador
                await HttpContext.SignInAsync("MyCookieAuth", claimsprincipal);
                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}
