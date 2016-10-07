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
        private IEventData _eventData;
        private readonly UserManager<ApplicationUser> _userManager;

        public CharacterController(
            ICharacterData characterData,
            IAbilityData abilityData,
            IEventData eventData,
            UserManager<ApplicationUser> userManager)
        {
            _characterData = characterData;
            _abilityData = abilityData;
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
            model.Events = _eventData.GetAll();
            return View(model);
        }
    }
}
