using Microsoft.AspNetCore.Mvc;
using WebAppMVCClientLocation.Data;
using WebAppMVCClientLocation.Models;

namespace WebAppMVCClientLocation.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View(Database.Clients);
        }

        [HttpPost]
        public IActionResult CreateClient(Client client)
        {
            Database.AddClient(client);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View("Create");
        }
    }
}
