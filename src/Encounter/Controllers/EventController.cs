using Encounter.Entities;
using Encounter.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Encounter.Controllers
{
    public class EventController : Controller
    {
        private IGameData _gameData;
        private ICharacterData _characterData;
        private IEventData _eventData;
        private IFoeData _foeData;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventController(
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
    }
}
