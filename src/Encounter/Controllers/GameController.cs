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
    [Route("[controller]")]
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
        [Route("[action]/{id}")]
        public IActionResult Create(int id)
        {
            var model = new CharacterPageViewModel();
            //model.Player = _playerData.Get(id);
            model.Characters = _characterData.GetAll();
            return View(model);
        }

        [HttpPost]
        [ActionName("Create")]
        [Route("[action]/Player/{playerId}/Character/{charId}")]
        public IActionResult CreateGameFormSubmit(int playerId, int charId)
        {
            int gameId =_gameData.Add(playerId, charId);
            return RedirectToAction("Game", new { playerId = playerId, charId = charId, gameId = gameId });
        }

        [Route("play")]
        [Route("Player/{playerId}/Character/{charId}/Game/{gameId}")]
        public IActionResult Game(int playerId, int charId, int gameId)
        {
            var model = new GamePageViewModel();
            model.CurrentPlayer = _playerData.Get(playerId);
            //System.Diagnostics.Debug.WriteLine(model.CurrentGame.Created);
            //model.SelectedCharacter = _characterData.Get(charId);
            //model.CurrentGame = _gameData.Get(gameId);
            return View(model);
        }
    }
}
