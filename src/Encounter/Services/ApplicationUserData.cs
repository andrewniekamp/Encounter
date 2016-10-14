using Encounter.Entities;
using Microsoft.AspNetCore.Identity;
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
        void AddGameToUser(Game game);
        ICollection<ApplicationUser> GetAllUsers(); 
    }
    public class SqlApplicationUserData : IApplicationUserData
    {
        private EncounterDbContext _context;

        public SqlApplicationUserData(EncounterDbContext context)
        {
            _context = context;
        }
        public void AddGameToUser(Game game)
        {

        }

        public ICollection<ApplicationUser> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Games)
                .ThenInclude(g => g.Character)
                .ThenInclude(c => c.Abilities)
                .ToList();
        }
    }
}
