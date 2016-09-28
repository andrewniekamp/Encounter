using Encounter.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Encounter.Services
{
    public interface IPlayerData
    {
        IEnumerable<Player> GetAll();
        Player Get(int id);
        Player GetByUserId(string id);
        void Add(Player newPlayer);
    }

    public class SqlPlayerData : IPlayerData
    {
        private EncounterDbContext _context;

        public SqlPlayerData(EncounterDbContext context)
        {
            _context = context;
        }
        public void Add(Player newPlayer)
        {
            _context.Add(newPlayer);
            _context.SaveChanges();
        }

        //public void AddGame(Game newGame, int id)
        //{
        //    _context.Players.FirstOrDefault(c => c.PlayerId == id).GameInstance = newGame;
        //    _context.SaveChanges();
        //}

        public Player Get(int id)
        {
            return _context.Players.FirstOrDefault(c => c.PlayerId == id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players.ToList();
        }

        public Player GetByUserId(string id)
        {
            return _context.Players.FirstOrDefault(c => c.User.Id == id);
        }
    }

    public class InMemoryPlayerData : IPlayerData
    {
        static InMemoryPlayerData()
        {
            _players = new List<Player>
            {
                new Player { PlayerId = 1, Name = "Natsu" },
                new Player { PlayerId = 2, Name = "Gray" },
                new Player { PlayerId = 3, Name = "Juvia" }
            };
        }

        public IEnumerable<Player> GetAll()
        {
            return _players;
        }

        public Player Get(int id)
        {
            return _players.FirstOrDefault(c => c.PlayerId == id);
        }

        public void Add(Player newPlayer)
        {
            newPlayer.PlayerId = _players.Max(c => c.PlayerId) + 1;
            _players.Add(newPlayer);
        }

        public Player GetByUserId(string id)
        {
            throw new NotImplementedException();
        }

        static List<Player> _players;
    }
}
