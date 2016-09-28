using Encounter.Entities;
using Encounter.Services;
using Encounter.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Encounter.Services.SqlAbilityData;

namespace Encounter.Controllers
{
    [Route("[controller]")]
    public class AbilityController : Controller
    {
        private ICharacterData _characterData;
        private IAbilityData _gameData;
        private IPlayerData _playerData;
        private IAbilityData _abilityData;

        public AbilityController(
            IPlayerData playerData,
            IAbilityData gameData,
            ICharacterData characterData,
            IAbilityData abilityData)
        {
            _playerData = playerData;
            _gameData = gameData;
            _characterData = characterData;
            _abilityData = abilityData;
        }

        [Route("play")]
        [Route("Player/{playerId}/Character/{charId}/Game/{gameId}")]
        public IActionResult Index(int playerId, int charId, int gameId)
        {
            //add abilities with character ID in this view...
            var model = new AbilityPageViewModel();
            model.CurrentPlayer = _playerData.Get(playerId);
            //System.Diagnostics.Debug.WriteLine(model.CurrentAbility.Created);
            //model.SelectedCharacter = _characterData.Get(charId);
            model.Abilities = _abilityData.GetAll();
            return View(model);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Create(int id)
        {
            var model = new CharacterPageViewModel();
            model.Player = _playerData.Get(id);
            model.Characters = _characterData.GetAll();
            return View(model);
        }

        //[HttpPost]
        //[ActionName("Create")]
        //[Route("[action]/Player/{playerId}/Character/{charId}")]
        //public IActionResult CreateAbilityFormSubmit(int playerId, int charId)
        //{
        //    int gameId =_gameData.Add(playerId, charId);
        //    return RedirectToAction("Ability", new { playerId = playerId, charId = charId, gameId = gameId });
        //}
    }
}
