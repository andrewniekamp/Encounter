﻿using Encounter.Entities;
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

        //Method to generate temp/initial values to the DB
        [HttpPost]
        public async Task<IActionResult> GenerateData()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            List<Character> chars = _characterData.GetAll().ToList();

            if (chars.Count == 0)
            {
                _abilityData.Add(new Ability { Name = "Hammer Blow", FoeHarm = 3, ImageUrl = "/img/actions/hammer-blow.png" });
                _abilityData.Add(new Ability { Name = "Piercing Arrow", FoeHarm = 3, ImageUrl = "/img/actions/piercing-arrow.png" });
                _abilityData.Add(new Ability { Name = "Stab", FoeHarm = 3, ImageUrl = "/img/actions/stab.png" });
                _abilityData.Add(new Ability { Name = "Inspiring Speech", CharHeal = 3, FoeHeal = 1, ImageUrl = "/img/actions/inspiring-speech.png" });
                _abilityData.Add(new Ability { Name = "Heal", CharHeal = 2, ImageUrl = "/img/actions/heal.png" });
                _abilityData.Add(new Ability { Name = "Shove", FoeHarm = 1, ImageUrl = "/img/actions/shove.png" });
                _abilityData.Add(new Ability { Name = "Snide Remark", FoeHarm = 1, ImageUrl = "/img/actions/snide-remark.png" });
                _abilityData.Add(new Ability { Name = "Belittling Glare", FoeHarm = 2, ImageUrl = "/img/actions/belittling-glare.png" });
                _abilityData.Add(new Ability { Name = "Heal 2", CharHeal = 4, ImageUrl = "/img/actions/heal.png" });
                _abilityData.Add(new Ability { Name = "Claw Attack", FoeHarm = 3, ImageUrl = "/img/actions/claw-attack.png" });
                _abilityData.Add(new Ability { Name = "Rude Remark", FoeHarm = 1, ImageUrl = "/img/actions/snide-remark.png" });
                _abilityData.Add(new Ability { Name = "Salty Insult", FoeHarm = 2, ImageUrl = "/img/actions/heal.png" });

                _characterData.Add(new Character { Name = "Winterberry", SpriteUrl = "/img/char/cleric.png", Class="Cleric", Health = 20, Abilities = new List<Ability> { _abilityData.Get(1), _abilityData.Get(5) } });
                _characterData.Add(new Character { Name = "Clementine", SpriteUrl = "/img/char/ranger.png", Class = "Ranger", Health = 20, Abilities = new List<Ability> { _abilityData.Get(2), _abilityData.Get(6) } });
                _characterData.Add(new Character { Name = "Alfonse", SpriteUrl = "/img/char/rogue.png", Class = "Rogue", Health = 20, Abilities = new List<Ability> { _abilityData.Get(3), _abilityData.Get(7) } });
                _characterData.Add(new Character { Name = "Pat", SpriteUrl = "/img/char/captain.png", Class = "Captain", Health = 20, Abilities = new List<Ability> { _abilityData.Get(4), _abilityData.Get(8) } });

                _foeData.Add(new Foe { Health = 12, Name = "Ogre", SpriteUrl = "/img/foe/ogre.png", Abilities = new List<Ability> { _abilityData.Get(1), _abilityData.Get(4) } });
                _foeData.Add(new Foe { Health = 16, Name = "Desert Dweller", SpriteUrl = "/img/foe/desert-dweller.png", Abilities = new List<Ability> { _abilityData.Get(2), _abilityData.Get(6) } });
                _foeData.Add(new Foe { Health = 18, Name = "Strange Creatures", SpriteUrl = "/img/foe/flying-monster.png", Abilities = new List<Ability> { _abilityData.Get(3), _abilityData.Get(7) } });
                _foeData.Add(new Foe { Health = 22, Name = "Vampire", SpriteUrl = "/img/foe/vampire.png", Abilities = new List<Ability> { _abilityData.Get(8), _abilityData.Get(5) } });
                _foeData.Add(new Foe { Health = 30, Name = "Dragon", SpriteUrl = "/img/foe/dragon.png", Abilities = new List<Ability> { _abilityData.Get(9), _abilityData.Get(10) } });

            }

            return RedirectToAction("Index", "Account", currentUser);
        }

        [Route("play")]
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
        public IActionResult Next(int gameId, int eventsCompleted)
        {
            var model = new GamePageViewModel();
            model.Game = _gameData.Get(gameId);
            model.EventsCompleted = eventsCompleted;
            //model.RemainingEvents = model.Game.Events.Skip(eventsCompleted).ToList();
            if (eventsCompleted == model.Game.Events.Count)
            {
                return View("Win");
            }
            List<Event> sortedEvents = (from e in model.Game.Events orderby e.EventId ascending select e).ToList();
            model.CurrentEvent = sortedEvents.ElementAt(eventsCompleted);
            return View("EventNext", model);
        }
    }
}
