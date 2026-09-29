using Microsoft.AspNetCore.Mvc;
using WebAppMVCClientLocation.Data;
using WebAppMVCClientLocation.Models;

namespace WebAppMVCClientLocation.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index(List<Client> clients)
        {
            return View(clients);
        }

        public IActionResult Create(Client client)
        {
            Database.AddClient(client);
            return RedirectToAction("Index");
        }
    }
}
