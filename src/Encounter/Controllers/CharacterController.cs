using Encounter.Entities;
using Encounter.Services;
using Encounter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Encounter.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterData _characterData;
        private IAbilityData _abilityData;
        private IScenarioData _scenarioData;
        private IEventData _eventData;
        private readonly UserManager<ApplicationUser> _userManager;

        public CharacterController(
            ICharacterData characterData,
            IAbilityData abilityData,
            IScenarioData scenarioData,
            IEventData eventData,
            UserManager<ApplicationUser> userManager)
        {
            _characterData = characterData;
            _abilityData = abilityData;
            _scenarioData = scenarioData;
            _eventData = eventData;
            _userManager = userManager;
        }

        //public CharacterController()
        //{

        //}

        public async Task<IActionResult> Index()
        {
            var model = new CharacterPageViewModel();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            model.User = currentUser;
            model.Characters = _characterData.GetAll();
            model.Abilities = _abilityData.GetAll();
            return View(model);
        }
        public async Task<IActionResult> Scenario(int charId)
        {
            _scenarioData.Generate();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            var model = new CharacterPageViewModel();
            model.User = currentUser;
            model.SelectedCharacter = _characterData.Get(charId);
            model.Scenarios = _scenarioData.GetAll();

            return View(model);
        }
    }
}
