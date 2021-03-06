﻿using Encounter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface IGameData
    {
        IEnumerable<Game> GetAll();
        Game Get(int id);
        void Add(Game newGame);
        void AddGameToUser(string userId, Game Game);
        ICollection<Game> GetGamesOfUser(string userId);
    }

    public class SqlGameData : IGameData
    {
        private EncounterDbContext _context;

        public SqlGameData(EncounterDbContext context)
        {
            _context = context;
        }

        public void Add(Game newGame)
        {
            _context.Games.Add(newGame);
            _context.SaveChanges();
        }

        public void AddGameToUser(string userId, Game game)
        {
            _context.Users.FirstOrDefault(u => u.Id == userId).Games.Add(game);
            _context.SaveChanges();
        }

        public Game Get(int id)
        {
            //many includes
            return _context.Games
                .Include(g => g.User)
                .Include(g => g.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability1)
                .Include(g => g.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability2)
                .Include(g => g.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability3)
                .Include(g => g.Character).ThenInclude(c => c.Ability1)
                .Include(g => g.Character).ThenInclude(c => c.Ability2)
                .Include(g => g.Character).ThenInclude(c => c.Ability3)
                .FirstOrDefault(g => g.GameId == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.ToList();
        }

        public ICollection<Game> GetGamesOfUser(string userId)
        {
            return _context.Games
                .Include(g => g.Events).ThenInclude(e => e.Foe)
                .Include(g => g.Events).ThenInclude(e => e.Scenario)
                .Include(g => g.Character).ThenInclude(c => c.Ability1)
                .Include(g => g.Character).ThenInclude(c => c.Ability2)
                .Include(g => g.Character).ThenInclude(c => c.Ability3)
                .Where(m => m.User.Id == userId).ToList();
        }
    }




}
