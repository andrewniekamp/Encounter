using Encounter.Entities;
using Encounter.Services;
using Encounter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Encounter.Controllers
{
    public class GameController : Controller
    {
        private IGameData _gameData;
        private ICharacterData _characterData;
        private IAbilityData _abilityData;
        private IEventData _eventData;
        private IScenarioData _scenarioData;
        private IFoeData _foeData;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameController(
            IGameData gameData,
            ICharacterData characterData,
            IAbilityData abilityData,
            IEventData eventData,
            IScenarioData scenarioData,
            IFoeData foeData,
            UserManager<ApplicationUser> userManager)
        {
            _gameData = gameData;
            _characterData = characterData;
            _abilityData = abilityData;
            _eventData = eventData;
            _scenarioData = scenarioData;
            _foeData = foeData;
            _userManager = userManager;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        [Route("Character/{charId}/Scenario/{scenarioId}")]
        public async Task<IActionResult> Game(int charId, int scenarioId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            
            Scenario currentScenario = _scenarioData.Get(scenarioId);
            List<Event> scenarioEvents = _eventData.Generate(scenarioId).ToList();


            
            Game newGame = new Game();
            newGame.DateCreated = DateTime.Now;
            newGame.Character = _characterData.Get(charId);
            newGame.User = currentUser;
            newGame.Events = scenarioEvents;

            _gameData.Add(newGame);
            _gameData.AddGameToUser(userId, newGame);

            var model = new GamePageViewModel();
            model.Game = _gameData.Get(newGame.GameId);
            model.EventsCompleted = 0;
            model.CurrentEvent = currentScenario.Events.First();
            return View("EventNext", model);
        }

        public IActionResult Act(int id)
        {
            var actAbility = _abilityData.Get(id);
            return Json(actAbility);
        }

        public IActionResult FoeAct(int id)
        {
            var actAbility = _abilityData.Get(id);
            return Json(actAbility);
        }

        [HttpPost]
        [Route("Game/{gameId}/{eventsCompleted}")]
        public IActionResult Next(int gameId, int eventsCompleted)
        {
            var model = new GamePageViewModel();
            model.Game = _gameData.Get(gameId);
            model.EventsCompleted = eventsCompleted;
            model.LastEvent = false;
            if (eventsCompleted == model.Game.Events.Count -1)
            {
                model.LastEvent = true;
            }
            if (eventsCompleted == model.Game.Events.Count)
            {
                return View("Win");
            }
            List<Event> sortedEvents = (from e in model.Game.Events orderby e.EventId ascending select e).ToList();
            model.CurrentEvent = sortedEvents.ElementAt(eventsCompleted);
            return View("EventNext", model);
        }

        [Route("Demo/{eventsCompleted}")]
        public IActionResult Demo(int eventsCompleted)
        {
            Scenario currentScenario = _scenarioData.Demo();
            List<Event> scenarioEvents = _eventData.Generate(currentScenario.ScenarioId).ToList();
            
            Game demoGame = new Game();
            demoGame.Character = _characterData.Demo();
            demoGame.Events = scenarioEvents;

            var model = new GamePageViewModel();
            model.Game = demoGame;
            model.EventsCompleted = eventsCompleted;

            if (eventsCompleted == model.Game.Events.Count)
            {
                return View("Win");
            }

            List<Event> sortedEvents = (from e in model.Game.Events orderby e.EventId ascending select e).ToList();
            model.CurrentEvent = sortedEvents.ElementAt(eventsCompleted);
            model.CurrentEvent.Foe = _foeData.Demo(eventsCompleted);
            return View("Demo", model);
        }

        public IActionResult GameOver()
        {
            return View();
        }
    }
}
