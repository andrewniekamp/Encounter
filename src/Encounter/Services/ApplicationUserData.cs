using Encounter.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface IApplicationUserData
    {
        void AddGameToUser(Game game);
    }
    public class SqlApplicationUserData : IApplicationUserData
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private EncounterDbContext _context;

        public SqlApplicationUserData(EncounterDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void AddGameToUser(Game game)
        {

        }
    }
}
