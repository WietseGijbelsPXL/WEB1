using Microsoft.AspNetCore.Mvc;
using MVCFifa.Data;
using MVCFifa.Models;

namespace MVCFifa.Controllers
{
    public class PlayerController : Controller
    {
        AppDbContext _context;

        public PlayerController(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            var players = _context.Players;
            return View(players);
        }

        public IActionResult Create()
        {
            var player = new Player();
            return View(player);
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                AddPlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        private void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public IActionResult Details(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        public IActionResult Edit(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                UpdatePlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        private void UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
        }

        public IActionResult Delete(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        public IActionResult Delete(int id, Player player)
        {
            var playerToDelete = _context.Players.FirstOrDefault(p => p.PlayerId == id);
            if (playerToDelete == null)
            {
                return NotFound();
            }
            DeletePlayer(playerToDelete);
            return RedirectToAction("Index");
        }

        private void DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
        }
    }
}
