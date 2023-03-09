﻿using ECommerceSite.Data;
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

        public async Task<IActionResult> Index()
        {
            // Get all games from the DB
            //List<Game> games = _context.Games.ToList();
            
            // this is also another way to do
            List<Game> games = await (from game in _context.Games
                                select game).ToListAsync();

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

                return RedirectToAction("Index");
            }
            return View(gameModel);
        }
    }
}
