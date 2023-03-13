using ECommerceSite.Data;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly GameContext _context;
        public MembersController(GameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {
            if(ModelState.IsValid)
            {
                // Map RegisterViewModel data to Member object
                Member newMember = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };

                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View(regModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if(ModelState.IsValid)
            {
                // Check DB for credentials
                Member? m = (from member in _context.Members
                           where member.Email == loginModel.Email
                           && member.Password == loginModel.Password
                           select member).SingleOrDefault();
                
                // if exists, send back to the homepage
                if (m != null)
                {
                    HttpContext.Session.SetString("Email", loginModel.Email);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Credentials Not Found!!!");
            }

            // Return page if no record is found/ModelState is invalid
            return View(loginModel);
        }
    }
}
