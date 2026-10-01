using Microsoft.AspNetCore.Mvc;
using WebAppMVCClientLocation.Data;
using WebAppMVCClientLocation.ViewModels;

namespace WebAppMVCClientLocation.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View(Database.Locations);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult CreateLocation(LocationViewModel location)
        {
            Database.AddLocation(location);
            return RedirectToAction("Index");
        }
    }
}
