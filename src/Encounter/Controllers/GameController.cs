using Encounter.Entities;
using Encounter.Services;
using Encounter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Encounter.Controllers
{
    [Route("[controller]")]
    public class GameController : Controller
    {
        private IGameData _gameData;
        private ICharacterData _characterData;
        private IEventData _eventData;
        private IFoeData _foeData;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameController(
            IGameData gameData,
            ICharacterData characterData,
            IEventData eventData,
            IFoeData foeData,
            UserManager<ApplicationUser> userManager)
        {
            _gameData = gameData;
            _characterData = characterData;
            _eventData = eventData;
            _foeData = foeData;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[Route("[action]/{id}")]
        //public IActionResult Create(int id)
        //{
        //    var model = new CharacterPageViewModel();
        //    //model.Player = _playerData.Get(id);
        //    model.Characters = _characterData.GetAll();
        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Create")]
        //[Route("[action]/Player/{playerId}/Character/{charId}")]
        //public IActionResult CreateGameFormSubmit(int playerId, int charId)
        //{
        //    int gameId =_gameData.Add(playerId, charId);
        //    return RedirectToAction("Game", new { playerId = playerId, charId = charId, gameId = gameId });
        //}

        [Route("play")]
        [Route("Character/{charId}/Abilities/{abil1Id}/{abil2Id}")]
        public async Task<IActionResult> Game(int charId, int abil1Id, int abil2Id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            //TODO clean up how game is instantiated and saved - not able to Get events properly yet
            var model = new GamePageViewModel();
            model.User = currentUser;
            model.Character = _characterData.Get(charId);

            ICollection<Event> events = new Collection<Event>();
            events.Add(_eventData.Get(1));
            events.Add(_eventData.Get(2));
            model.Events = events;

            Game newGame = new Game();
            newGame.DateCreated = DateTime.Now;
            newGame.Character = model.Character;
            newGame.User = model.User;
            newGame.Events = model.Events;

            //_gameData.AddGameToUser(userId, Game);
            
            //TODO instantiate a new game and assign properties to it - and assign game to user - save in DB from svc
            return View(newGame);
        }
    }
}
