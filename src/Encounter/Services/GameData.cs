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
        int Add(int playerId, int selectedCharId);
    }

    public class SqlGameData : IGameData
    {
        private EncounterDbContext _context;

        public SqlGameData(EncounterDbContext context)
        {
            _context = context;
        }

        public int Add(int playerId, int selectedCharId)
        {
            Character newCharacterInstance = _context.Characters.FirstOrDefault(c => c.CharacterId == selectedCharId);
            Player thePlayer = _context.Players.FirstOrDefault(p => p.PlayerId == playerId);
            Game newGame = new Game { Character = newCharacterInstance, Created = DateTime.Now };
            _context.Players.FirstOrDefault(p => p.PlayerId == playerId).GameInstance = newGame;
            _context.SaveChanges();
            return newGame.GameId;

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
