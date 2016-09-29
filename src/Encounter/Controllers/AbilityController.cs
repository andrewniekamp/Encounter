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
using static Encounter.Services.SqlAbilityData;

namespace Encounter.Controllers
{
    public class AbilityController : Controller
    {
        private ICharacterData _characterData;
        private IAbilityData _abilityData;
        private readonly UserManager<ApplicationUser> _userManager;

        public AbilityController(
            ICharacterData characterData,
            IAbilityData abilityData,
            UserManager<ApplicationUser> userManager)
        {
            _characterData = characterData;
            _abilityData = abilityData;
            _userManager = userManager;
        }

        [Route("Character/{charId}/Abilities")]
        public async Task<IActionResult> Index(int id)
        {
            //add abilities with character ID in this view...
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            var model = new AbilityPageViewModel();
            model.Character = _characterData.Get(id);
            model.User = currentUser;
            model.Abilities = _abilityData.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var model = new CharacterPageViewModel();
            //model.User = find user here
            model.Characters = _characterData.GetAll();
            return View(model);
        }
    }
}
