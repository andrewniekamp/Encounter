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
        void Add(Game newGame);
    }

    public class InMemoryGameData : IGameData
    {
        static InMemoryGameData()
        {
            _games = new List<Game>
            {
                new Game { GameId = 1 },
                new Game { GameId = 2 },
                new Game { GameId = 3 }
            };
        }

        IEnumerable<Game> IGameData.GetAll()
        {
            return _games;
        }

        Game IGameData.Get(int id)
        {
            return _games.FirstOrDefault(g => g.GameId == id);
        }

        public void Add(Game newGame)
        {
            newGame.GameId = _games.Max(c => c.GameId) + 1;
            _games.Add(newGame);
        }

        static List<Game> _games;
    }


}
