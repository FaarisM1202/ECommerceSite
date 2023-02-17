using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Create() { 
            return View(); 
        }
    }
}
