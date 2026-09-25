using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebAppClient.Data;

namespace RazorWebAppClient.Pages
{
    public class NieuweLocatieModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string postcode = Request.Form["Postcode"];
            string gemeente = Request.Form["Gemeente"];
            Databank.AddLocatie(postcode, gemeente);
            return RedirectToPage("/Locatie");
        }
    }
}
