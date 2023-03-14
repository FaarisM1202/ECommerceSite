using ECommerceSite.Data;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly GameContext _context;

        public CartController(GameContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Game? gameToAdd = _context.Games.Where(g => g.GameId == id).SingleOrDefault();
            
            if(gameToAdd == null)
            {
                // Game without id doesn't exists
                TempData["Message"] = "Sorry! That game no longer exists.";
                return RedirectToAction("Index", "Games");
            }

            // ToDo: Add item to the shopping cart
            TempData["Message"] = "Item is added to the cart!";
            return RedirectToAction("Index", "Games");
        }
    }
}
