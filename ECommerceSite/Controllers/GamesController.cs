using ECommerceSite.Data;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameContext _context;
        public GamesController(GameContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create() { 
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game newGame)
        {
            if(ModelState.IsValid)
            {
                _context.Games.Add(newGame);
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{newGame.Title} was added successfully";
                return View();
            }
            return View(newGame);
        }
    }
}
