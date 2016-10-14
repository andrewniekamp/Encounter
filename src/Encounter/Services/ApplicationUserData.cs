using Encounter.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface IApplicationUserData
    {
        ICollection<ApplicationUser> GetAllUsers();
        void DeleteUser(string id);
        void DeleteGame(int id);
    }
    public class SqlApplicationUserData : IApplicationUserData
    {
        private EncounterDbContext _context;

        public SqlApplicationUserData(EncounterDbContext context)
        {
            _context = context;
        }

        public ICollection<ApplicationUser> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Games)
                .ThenInclude(g => g.Character)
                .ThenInclude(c => c.Abilities)
                .ToList();
        }
        
        public void DeleteUser(string id)
        {
            var thisUser = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(thisUser);
            _context.SaveChanges();
        }
        
        public void DeleteGame(int id)
        {
            var thisGame = _context.Games.FirstOrDefault(u => u.GameId == id);

            _context.Events.RemoveRange(_context.Events.Where(e => e.Game == thisGame));
            _context.Games.Remove(thisGame);
            _context.SaveChanges();
        }
    }
}
