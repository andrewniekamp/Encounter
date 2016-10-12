using Encounter.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Encounter.Services
{
    public interface ICharacterData
    {
        IEnumerable<Character> GetAll();
        Character Get(int id);
        void Add(Character newCharacter);
    }

    public class SqlCharacterData : ICharacterData
    {
        private EncounterDbContext _context;

        public SqlCharacterData(EncounterDbContext context)
        {
            _context = context;
        }
        public void Add(Character newCharacter)
        {
            _context.Add(newCharacter);
            _context.SaveChanges();
        }
        public Character Get(int id)
        {
            return _context.Characters.Include(c => c.Abilities).FirstOrDefault(c => c.CharacterId == id);
        }

        public IEnumerable<Character> GetAll()
        {
            return _context.Characters.ToList();
        }
    }
}
