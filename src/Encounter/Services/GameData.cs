using Encounter.Entities;
using Microsoft.EntityFrameworkCore;
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
        void AddGameToUser(string userId, Game Game);
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
            Game newGame = new Game { Character = newCharacterInstance, DateCreated = DateTime.Now };
            _context.Players.FirstOrDefault(p => p.PlayerId == playerId).GameInstance = newGame;
            _context.SaveChanges();
            return newGame.GameId;

        }

        public void AddGameToUser(string userId, Game game)
        {
            _context.Users.FirstOrDefault(u => u.Id == userId).Games.Add(game);
            _context.SaveChanges();
        }

        public Game Get(int id)
        {
            //example of multiple includes
            return _context.Games.Include(c => c.Events)
                .ThenInclude(c => c.Foe)
                .ThenInclude(c => c.Abilities).FirstOrDefault(g => g.GameId == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.ToList();
        }
    }




}
