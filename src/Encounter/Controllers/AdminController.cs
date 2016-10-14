using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Encounter.Services;
using Encounter.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Encounter.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IApplicationUserData _applicationUserData;
        private IGameData _gameData;
        private ICharacterData _characterData;
        private IAbilityData _abilityData;
        private IEventData _eventData;
        private IFoeData _foeData;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(
            IApplicationUserData applicationUserData,
            IGameData gameData,
            ICharacterData characterData,
            IAbilityData abilityData,
            IEventData eventData,
            IFoeData foeData,
            UserManager<ApplicationUser> userManager)
        {
            _applicationUserData = applicationUserData;
            _gameData = gameData;
            _characterData = characterData;
            _abilityData = abilityData;
            _eventData = eventData;
            _foeData = foeData;
            _userManager = userManager;
        }
        
        public IActionResult Index()
        {
            ICollection<ApplicationUser> allUsers = _applicationUserData.GetAllUsers();
            return View(allUsers);
        }
    }
}
