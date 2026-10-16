using Microsoft.AspNetCore.Mvc;
using MVCFifa.Data;
using MVCFifa.Models;
using MVCFifa.ViewModels;
using System.Numerics;

namespace MVCFifa.Controllers
{
    public class TeamController : Controller
    {
        AppDbContext _context;
        IWebHostEnvironment _environment;

        public TeamController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
        public IActionResult Index()
        {
            var teams = _context.Teams;
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public IActionResult Details(int id)
        {
            var team = _context.Teams.FirstOrDefault(t => t.TeamId == id);
            var fileExists = false;
            if (team.ImageLinkClub != null)
            {
                var path = _environment.WebRootPath;
                var file = Path.Combine($"{path}\\images", team.ImageLinkClub);
                fileExists = System.IO.File.Exists(file);
            }
            ViewBag.FileExists = fileExists;
            return View(team);
        }

        public IActionResult UploadImage(int id)
        {
            var team = _context.Teams.FirstOrDefault(t => t.TeamId == id);
            var teamImage = new TeamImageViewModel
            {
                Id = team.TeamId,
            };
            return View(teamImage);
        }

        [HttpPost]
        public IActionResult UploadImage(TeamImageViewModel teamImage)
        {
            if (ModelState.IsValid)
            {
                if (teamImage.ImageFile == null || teamImage.ImageFile.Length == 0)
                {
                    ModelState.AddModelError("", "Please select an image.");
                }
                else
                {
                    var team = _context.Teams.FirstOrDefault(x => x.TeamId == teamImage.Id);
                    if (team != null)
                    {
                        var imagesFolder = Path.Combine(
                        _environment.WebRootPath, "images");
                        var extension = Path.GetExtension(teamImage.ImageFile!.FileName);
                        var fileName = $"{Guid.NewGuid():N}{extension}";
                        var filePath = Path.Combine(imagesFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            teamImage.ImageFile.CopyTo(stream);
                        }
                        team.ImageLinkClub = fileName;
                        _context.Teams.Update(team);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}
