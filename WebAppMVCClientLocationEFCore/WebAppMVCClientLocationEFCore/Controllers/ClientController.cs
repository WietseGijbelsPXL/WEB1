using Microsoft.AspNetCore.Mvc;
using WebAppMVCClientLocationEFCore.Data;
using WebAppMVCClientLocationEFCore.Models;

namespace WebAppMVCClientLocationEFCore.Controllers
{
    public class ClientController : Controller
    {
        ClientLocationContext _context;

        public ClientController(ClientLocationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            return View(client);
        }   
    }
}
