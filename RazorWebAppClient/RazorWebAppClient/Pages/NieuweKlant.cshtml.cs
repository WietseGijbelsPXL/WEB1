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
            string locatieId = Request.Form["LocatieId"];
            Databank.AddKlant(naam, int.Parse(locatieId));
            return RedirectToPage("/Klant");
        }
    }
}
