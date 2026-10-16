using Microsoft.AspNetCore.Mvc;
using MVCFifa.Data;
using MVCFifa.Models;
using MVCFifa.ViewModels;

namespace MVCFifa.Controllers
{
    public class PlayerController : Controller
    {
        AppDbContext _context;
        IWebHostEnvironment _environment;

        public PlayerController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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
            var fileExists = false;
            if(player.ImageLink != null)
            {
                var path = _environment.WebRootPath;
                var file = Path.Combine($"{path}\\images", player.ImageLink);
                fileExists = System.IO.File.Exists(file);
            }
            ViewBag.FileExists = fileExists;
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

        public IActionResult UploadImage(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == id);
            var playerImage = new PlayerImageViewModel
            {
                Id = player.PlayerId,
            };
            return View(playerImage);
        }

        [HttpPost]
        public IActionResult UploadImage(PlayerImageViewModel playerImage)
        {
            if (ModelState.IsValid)
            {
                if (playerImage.ImageFile == null || playerImage.ImageFile.Length == 0)
                {
                    ModelState.AddModelError("", "Please select an image.");
                }
                else
                {
                    var player = _context.Players.FirstOrDefault(x => x.PlayerId == playerImage.Id);
                    if (player != null)
                    {
                        var imagesFolder = Path.Combine(
                        _environment.WebRootPath, "images");
                        var extension = Path.GetExtension(playerImage.ImageFile!.FileName);
                        var fileName = $"{Guid.NewGuid():N}{extension}";
                        var filePath = Path.Combine(imagesFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            playerImage.ImageFile.CopyTo(stream);
                        }
                        player.ImageLink = fileName;
                        _context.Players.Update(player);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}
