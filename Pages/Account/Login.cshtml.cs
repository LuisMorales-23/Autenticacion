using Microsoft.AspNetCore.Mvc;
using Autenticacion.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace Autenticacion.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]

        public User user { get; set; }

    public void OnGet()
        {
            Console.WriteLine("User :" + user.Email + " Password : " + user.Password );

        }
    }
}
