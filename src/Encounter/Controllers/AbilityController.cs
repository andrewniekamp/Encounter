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

        [HttpPost]
        [Route("Character/{charId}/Abilities")]
        public async Task<IActionResult> Index(int charId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            var model = new AbilityPageViewModel();
            model.Character = _characterData.Get(charId);
            model.User = currentUser;
            model.Abilities = _abilityData.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ready(int charId)
        {
            //temporary abilities
            ICollection<Ability> abilities = new List<Ability>();
            Ability totalMess = new Ability
            {
                AbilityId = 1,
                CharHarm = 1,
                CharHeal = 3,
                FoeHarm = 5,
                FoeHeal = 2,
                Name = "Total Mess"
            };
            Ability powerUp = new Ability
            {
                AbilityId = 2,
                CharHarm = 0,
                CharHeal = 10,
                FoeHarm = 0,
                FoeHeal = 10,
                Name = "Power Up"
            };
            abilities.Add(totalMess);
            abilities.Add(powerUp);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            var model = new AbilityPageViewModel();
            model.User = currentUser;
            // may not need - model.Abilities = abilities;
            model.Character = _characterData.Get(charId);
            model.Character.Abilities = abilities;
            return View(model);
        }
    }
}
