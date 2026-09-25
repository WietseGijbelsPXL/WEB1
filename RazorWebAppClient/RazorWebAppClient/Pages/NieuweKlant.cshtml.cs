using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebAppClient.Data;

namespace RazorWebAppClient.Pages
{
    public class NieuweKlantModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string naam = Request.Form["KlantNaam"];
            Databank.AddKlant(naam);
            return RedirectToPage("/Klant");
        }
    }
}
