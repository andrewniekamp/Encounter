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
        private IFoeData _foeData;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameController(
            IGameData gameData,
            ICharacterData characterData,
            IAbilityData abilityData,
            IEventData eventData,
            IFoeData foeData,
            UserManager<ApplicationUser> userManager)
        {
            _gameData = gameData;
            _characterData = characterData;
            _abilityData = abilityData;
            _eventData = eventData;
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

            _abilityData.Add(new Ability { Name = "Attack", FoeHarm = 10 });
            _abilityData.Add(new Ability { Name = "Defend", FoeHarm = 0 });
            _abilityData.Add(new Ability { Name = "Kick", FoeHarm = 4 });
            _abilityData.Add(new Ability { Name = "Pray", FoeHarm = 0 });
            _abilityData.Add(new Ability { Name = "Shout", FoeHarm = 1 });
            _abilityData.Add(new Ability { Name = "Shove", FoeHarm = 2 });
            _abilityData.Add(new Ability { Name = "Total Mess", FoeHarm = 7 });
            _abilityData.Add(new Ability { Name = "Power Up", CharHeal = 10, FoeHeal = 10 });
            
            //_eventData.Add(new Event { Name = "Forest", ImageUrl = "/img/forest.jpg" });
            //_eventData.Add(new Event { Name = "Mountains", ImageUrl = "/img/mountains.jpg" });
            
            _characterData.Add(new Character { Name = "Winterberry", SpriteUrl = "/img/gnome.png", Health = 20, Abilities = new List<Ability> { _abilityData.Get(1), _abilityData.Get(5) } });
            _characterData.Add(new Character { Name = "Clementine", SpriteUrl = "/img/monk.png", Health = 20, Abilities = new List<Ability> { _abilityData.Get(2), _abilityData.Get(6) } });
            _characterData.Add(new Character { Name = "Alfonse", SpriteUrl = "/img/testchar.svg", Health = 20, Abilities = new List<Ability> { _abilityData.Get(3), _abilityData.Get(7) } });
            _characterData.Add(new Character { Name = "Patricia", SpriteUrl = "/img/pilot.png", Health = 20, Abilities = new List<Ability> { _abilityData.Get(4), _abilityData.Get(8) } });

            //_foeData.Add(new Foe { Health = 15, Name = "Gnoll", SpriteUrl = "/img/gnoll.png", Event = _eventData.Get(1), Abilities = new List<Ability> { _abilityData.Get(7), _abilityData.Get(8) } });
            //_foeData.Add(new Foe { Health = 11, Name = "Goblin", SpriteUrl = "/img/goblin.png", Event = _eventData.Get(2), Abilities = new List<Ability> { _abilityData.Get(3), _abilityData.Get(2) } });

            _foeData.Add(new Foe { Health = 16, Name = "Goblin", SpriteUrl = "/img/goblin.png", Abilities = new List<Ability> { _abilityData.Get(7), _abilityData.Get(8) } });
            _foeData.Add(new Foe { Health = 18, Name = "Gnoll", SpriteUrl = "/img/gnoll.png", Abilities = new List<Ability> { _abilityData.Get(7), _abilityData.Get(8) } });
            _foeData.Add(new Foe { Health = 20, Name = "Lizard Monster", SpriteUrl = "/img/lizard.png", Abilities = new List<Ability> { _abilityData.Get(7), _abilityData.Get(8) } });

            return RedirectToAction("Index", "Account", currentUser);
        }

        [Route("play")]
        [Route("Character/{charId}")]
        public async Task<IActionResult> Game(int charId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            //TODO May need to construct events here to avoid simply reassigning events already in db
            //_eventData.Add(new Event { Name = "Forest", ImageUrl = "/img/forest.jpg" });
            
            Event initialEvent = new Event { Name = "Desert", ImageUrl = "/img/desert1.jpg", Foe = _foeData.Get(1)};
            Event secondEvent = new Event { Name = "Desert", ImageUrl = "/img/desert2.jpg", Foe = _foeData.Get(2) };
            Event thirdEvent = new Event { Name = "Desert", ImageUrl = "/img/desert3.jpg", Foe = _foeData.Get(3) };
            Event fourthEvent = new Event { Name = "Desert", ImageUrl = "/img/desert4.jpg", Foe = _foeData.Get(1) };
            Event fifthEvent = new Event { Name = "Forest", ImageUrl = "/img/forest1.jpg", Foe = _foeData.Get(2) };
            //Event sixthEvent = new Event { Name = "Desert", ImageUrl = "/img/desert.jpg", Foe = _foeData.Get(3) };
            //Event seventhEvent = new Event { Name = "Mountain", ImageUrl = "/img/mountains.jpg", Foe = _foeData.Get(1) };
            //Event eighthEvent = new Event { Name = "Forest", ImageUrl = "/img/forest.jpg", Foe = _foeData.Get(2) };
            //Event ninthEvent = new Event { Name = "Desert", ImageUrl = "/img/desert.jpg", Foe = _foeData.Get(3) };
            //Event tenthEvent = new Event { Name = "Mountain", ImageUrl = "/img/mountains.jpg", Foe = _foeData.Get(1) };
            //Event twelfthEvent = new Event { Name = "Forest", ImageUrl = "/img/forest.jpg", Foe = _foeData.Get(2) };
            //Event thirteenthEvent = new Event { Name = "Desert", ImageUrl = "/img/desert.jpg", Foe = _foeData.Get(3) };

            _eventData.Add(initialEvent);
            _eventData.Add(secondEvent);
            _eventData.Add(thirdEvent);
            _eventData.Add(fourthEvent);
            _eventData.Add(fifthEvent);
            //_eventData.Add(sixthEvent);

            List<Event> events = new List<Event>();
            events.Add(initialEvent);
            events.Add(secondEvent);
            events.Add(thirdEvent);
            events.Add(fourthEvent);
            events.Add(fifthEvent);
            //events.Add(sixthEvent);

            Game newGame = new Game();
            newGame.DateCreated = DateTime.Now;
            newGame.Character = _characterData.Get(charId);
            newGame.User = currentUser;
            newGame.Events = events;

            _gameData.Add(newGame);
            _gameData.AddGameToUser(userId, newGame);
            
            //return View("Event", newGame);

            var model = new GamePageViewModel();
            model.Game = newGame;
            model.EventsCompleted = 0;
            //model.RemainingEvents = model.Game.Events.Skip(eventsCompleted).ToList();
            model.CurrentEvent = model.Game.Events.First();
            return View("EventNext", model);
        }

        public IActionResult Act(int id)
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
            List<Event> sortedEvents = (from e in model.Game.Events
                                            orderby e.EventId ascending
                                            select e).ToList();
            model.CurrentEvent = sortedEvents.ElementAt(eventsCompleted);
            return View("EventNext", model);
        }
    }
}
