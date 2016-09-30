using Encounter.Entities;
using Encounter.Services;
using Encounter.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Encounter.Services.SqlGameData;

namespace Encounter.Controllers
{
    [Route("[controller]")]
    public class GameController : Controller
    {
        private ICharacterData _characterData;
        private IGameData _gameData;
        private IPlayerData _playerData;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameController(
            IPlayerData playerData,
            IGameData gameData,
            ICharacterData characterData,
            UserManager<ApplicationUser> userManager)
        {
            _playerData = playerData;
            _gameData = gameData;
            _characterData = characterData;
            _userManager = userManager;
        }
        
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Create(int id)
        {
            var model = new CharacterPageViewModel();
            //model.Player = _playerData.Get(id);
            model.Characters = _characterData.GetAll();
            return View(model);
        }

        [HttpPost]
        [ActionName("Create")]
        [Route("[action]/Player/{playerId}/Character/{charId}")]
        public IActionResult CreateGameFormSubmit(int playerId, int charId)
        {
            int gameId =_gameData.Add(playerId, charId);
            return RedirectToAction("Game", new { playerId = playerId, charId = charId, gameId = gameId });
        }

        [Route("play")]
        [Route("Game/Character/{charId}/Abilities/{abil1Id}/{abil2Id}")]
        public async Task<IActionResult> Game(int charId, int abil1Id, int abil2Id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            var model = new GamePageViewModel();
            model.User = currentUser;
            model.Character = _characterData.Get(charId);

            //TODO instantiate a new game and assign properties to it - and assign game to user - save in DB from svc
            //model.CurrentGame = _gameData.Get(gameId);
            return View(model);
        }
    }
}
