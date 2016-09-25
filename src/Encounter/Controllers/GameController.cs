using Encounter.Entities;
using Encounter.Services;
using Encounter.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Encounter.Services.SqlGameData;

namespace Encounter.Controllers
{
    public class GameController : Controller
    {
        private ICharacterData _characterData;
        private IGameData _gameData;
        private IPlayerData _playerData;

        public GameController(
            IPlayerData playerData,
            IGameData gameData,
            ICharacterData characterData)
        {
            _playerData = playerData;
            _gameData = gameData;
            _characterData = characterData;
        }
        
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Create(int id)
        {
            var model = new CharacterPageViewModel();
            model.Player = _playerData.Get(id);
            model.Characters = _characterData.GetAll();
            return View(model);
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreateWithChar(int playerId, int charId)
        {
            _gameData.Add(playerId, charId);
            var model = new GamePageViewModel();
            model.CurrentPlayer = _playerData.Get(playerId);
            model.SelectedCharacter = _characterData.Get(charId);
            return View("Game", model);
        }
    }
}
