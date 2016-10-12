using Encounter.Entities;
using Microsoft.AspNetCore.Identity;
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
        string CreateMD5(string input);
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
        public string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
