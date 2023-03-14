using ECommerceSite.Data;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameContext _context;
        public GamesController(GameContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            const int NumGamesToDisplayPerPage = 3;
            const int PageOffset = 1; // Need a page offset to use current page and skip ones you don't need
            // shorter way of the if else statement
            int currPage = id ?? 1; // set current page to id if it has a value, else use a 1

            /**
            if(id.HasValue)
            {
                currPage = id.Value;
            }
            else
            {
                currPage = 1;
            }
            **/

            // Get all games from the DB
            //List<Game> games = _context.Games.ToList();

            // same thing as the one down below but shorter way.
            List<Game> games = _context.Games
                .Skip(NumGamesToDisplayPerPage * (currPage - PageOffset))
                .Take(NumGamesToDisplayPerPage)
                .ToList();
            
            // this is also another way to do
/*            List<Game> games = await (from game in _context.Games
                                select game).Skip(NumGamesToDisplayPerPage * (currPage - PageOffset))
                                            .Take(NumGamesToDisplayPerPage)                 
                                            .ToListAsync();*/

            // Show them on the page
            return View(games);
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

        public async Task<IActionResult> Edit(int id)
        {
            Game? gameToEdit = await _context.Games.FindAsync(id);
            if(gameToEdit == null)
            {
                return NotFound();
            }
            return View(gameToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game gameModel)
        {
            if(ModelState.IsValid)
            {
                _context.Games.Update(gameModel);
                await _context.SaveChangesAsync();

                // redirect them with a success message!
                TempData["Message"] = $"{gameModel.Title} was added successfully!";
                return RedirectToAction("Index");
            }
            return View(gameModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Game? gameToDelete = await _context.Games.FindAsync(id);

            if(gameToDelete == null)
            {
                return NotFound();
            }
            return View(gameToDelete);
        }

        /// <summary>
        /// In the ActionName, we need to refer it as "Delete"
        /// because we need a delete to be posted right above the method here.
        /// Reason is because C# won't allow it to be that way without making changes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Game gameToDelete = await _context.Games.FindAsync(id);

            if(gameToDelete != null)
            {
                _context.Games.Remove(gameToDelete);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{gameToDelete.Title} was deleted successfully!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This game was already deleted!!!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Game? gameToDetails = await _context.Games.FindAsync(id);

            if(gameToDetails == null)
            {
                return NotFound();
            }

            return View(gameToDetails);
        }
    }
}
