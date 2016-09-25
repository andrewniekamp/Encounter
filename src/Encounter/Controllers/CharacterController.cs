using Encounter.Services;
using Encounter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterData _characterData;
        private IPlayerData _playerData;

        public CharacterController(
            IPlayerData playerData,
            ICharacterData characterData)
        {
            _playerData = playerData;
            _characterData = characterData;
        }

        public IActionResult Index(int id)
        {
            var model = new CharacterPageViewModel();
            model.Player = _playerData.Get(id);
            model.Characters = _characterData.GetAll();
            return View(model);
        }

        //public IActionResult Generate(int id)
        //{
        //    _characterData.Generate();
        //
        //    var model = new CharacterPageViewModel();
        //    model.Player = _playerData.Get(id);
        //    model.Characters = _characterData.GetAll();
        //    return View(model);
        //}
    }
}
