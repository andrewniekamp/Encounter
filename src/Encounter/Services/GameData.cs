using Encounter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface IGameData
    {
        IEnumerable<Game> GetAll();
        Game Get(int id);
        void Add(int playerId, int selectedCharId);
    }

    public class SqlGameData : IGameData
    {
        private EncounterDbContext _context;

        public SqlGameData(EncounterDbContext context)
        {
            _context = context;
        }

        public void AddGameToPlayer(int id)
        {
            Game newGame = new Game { CharacterInstance = _context.Characters.First()};
            _context.Players.FirstOrDefault(p => p.PlayerId == id)
                .GameInstance = newGame;
            _context.SaveChanges();
        }

        public void Add(int playerId, int selectedCharId)
        {
            Character newCharacterInstance = _context.Characters.FirstOrDefault(c => c.CharacterId == playerId);
            Game newGame = new Game { CharacterInstance = newCharacterInstance };
            _context.Players.FirstOrDefault(p => p.PlayerId == selectedCharId).GameInstance = newGame;
            _context.SaveChanges();

        }

        public Game Get(int id)
        {
            return _context.Games.FirstOrDefault(g => g.GameId == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.ToList();
        }
    }




}
