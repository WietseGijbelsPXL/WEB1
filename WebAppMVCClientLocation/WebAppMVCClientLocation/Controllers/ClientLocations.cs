using Microsoft.AspNetCore.Mvc;
using WebAppMVCClientLocation.ViewModels;

namespace WebAppMVCClientLocation.Controllers
{
    public class ClientLocations : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
