using Microsoft.AspNetCore.Mvc;
using Encounter.ViewModels;
using Encounter.Services;
using Encounter.Entities;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Encounter.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private IGreeter _greeter;
        private ICategoryData _categoryData;
        private IPlayerData _playerData;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerController(
            UserManager<ApplicationUser> userManager,
            ICategoryData categoryData,
            IPlayerData playerData,
            IGreeter greeter)
        {
            _userManager = userManager;
            _categoryData = categoryData;
            _playerData = playerData;
            _greeter = greeter;
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

        [HttpPost]
        public async Task<IActionResult> Create(PlayerEditViewModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            var currentUser = await _userManager.FindByIdAsync(userId);
            var player = new Player();
            player.Name = model.Name;
            player.Created = DateTime.Now;
            player.User = currentUser;

            _playerData.Add(player);

            return RedirectToAction("Details", new { id = player.PlayerId });

        }

        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            
            return View(currentUser);
        }
    }
}
