using Microsoft.AspNetCore.Mvc;
using Encounter.ViewModels;
using Encounter.Services;
using Encounter.Entities;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Collections;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Encounter.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private IGameData _gameData;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerController(
            IGameData gameData, 
            UserManager<ApplicationUser> userManager)
        {
            _gameData = gameData;
            _userManager = userManager;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Landing()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            
            return View(currentUser);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            
            currentUser.Games = _gameData.GetGamesOfUser(userId);
            return View(currentUser);
        }
    }
}
