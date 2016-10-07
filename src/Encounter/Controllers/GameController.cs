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
            
            _characterData.Add(new Character { Name = "Alfonse", SpriteUrl = "/img/testchar.svg", Health = 20, Abilities = new List<Ability> { _abilityData.Get(1), _abilityData.Get(5) } });
            _characterData.Add(new Character { Name = "Branson", SpriteUrl = "/img/testchar.svg", Health = 20, Abilities = new List<Ability> { _abilityData.Get(2), _abilityData.Get(6) } });
            _characterData.Add(new Character { Name = "Cornelius", SpriteUrl = "/img/testchar.svg", Health = 20, Abilities = new List<Ability> { _abilityData.Get(3), _abilityData.Get(7) } });
            _characterData.Add(new Character { Name = "Drew", SpriteUrl = "/img/testchar.svg", Health = 20, Abilities = new List<Ability> { _abilityData.Get(4), _abilityData.Get(8) } });

            //_foeData.Add(new Foe { Health = 15, Name = "Gnoll", SpriteUrl = "/img/gnoll.png", Event = _eventData.Get(1), Abilities = new List<Ability> { _abilityData.Get(7), _abilityData.Get(8) } });
            //_foeData.Add(new Foe { Health = 11, Name = "Goblin", SpriteUrl = "/img/goblin.png", Event = _eventData.Get(2), Abilities = new List<Ability> { _abilityData.Get(3), _abilityData.Get(2) } });

            return RedirectToAction("Landing", "Player", currentUser);
        }

        [Route("play")]
        [Route("Character/{charId}")]
        public async Task<IActionResult> Game(int charId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            //TODO May need to construct events here to avoid simply reassigning events already in db
            //_eventData.Add(new Event { Name = "Forest", ImageUrl = "/img/forest.jpg" });
            Event initialEvent = new Event { Name = "Mountain", ImageUrl = "/img/mountains.jpg" };
            Event secondEvent = new Event { Name = "Forest", ImageUrl = "/img/forest.jpg" };
            Event thirdEvent = new Event { Name = "Desert", ImageUrl = "/img/desert.jpg" };
            _eventData.Add(initialEvent);
            _eventData.Add(secondEvent);
            _eventData.Add(thirdEvent);
            _foeData.Add(new Foe { Health = 16, Name = "Goblin", SpriteUrl = "/img/goblin.png", Event = initialEvent, Abilities = new List<Ability> { _abilityData.Get(7), _abilityData.Get(8) } });
            _foeData.Add(new Foe { Health = 18, Name = "Gnoll", SpriteUrl = "/img/gnoll.png", Event = secondEvent, Abilities = new List<Ability> { _abilityData.Get(7), _abilityData.Get(8) } });
            _foeData.Add(new Foe { Health = 20, Name = "Lizard Monster", SpriteUrl = "/img/lizard.png", Event = thirdEvent, Abilities = new List<Ability> { _abilityData.Get(7), _abilityData.Get(8) } });
            ICollection<Event> events = new Collection<Event>();
            events.Add(initialEvent);
            //events.Add(secondEvent);
            //events.Add(thirdEvent);

            Game newGame = new Game();
            newGame.DateCreated = DateTime.Now;
            newGame.Character = _characterData.Get(charId);
            newGame.User = currentUser;
            newGame.Events = events;

            _gameData.Add(newGame);
            _gameData.AddGameToUser(userId, newGame);
            
            return View("Event", newGame);
        }

        [ActionName("NextEvent")]
        public IActionResult Event(int gameId, int eventCount)
        {
            Game currentGame = _gameData.Get(gameId);
            return View("Event", currentGame);
        }

        public IActionResult Act(int id)
        {
            var actAbility = _abilityData.Get(id);
            return Json(actAbility);
        }
    }
}
