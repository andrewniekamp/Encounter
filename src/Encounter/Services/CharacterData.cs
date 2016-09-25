using Encounter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface ICharacterData
    {
        IEnumerable<Character> GetAll();
        Character Get(int id);
        void Add(Character newCharacter);
        void Generate();
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
            return _context.Characters.FirstOrDefault(c => c.CharacterId == id);
        }

        public IEnumerable<Character> GetAll()
        {
            return _context.Characters.ToList();
        }

        //re-tool later
        public void Generate()
        {
            Character Alfonse = new Character { CharacterId = 1, Name = "Alfonse", SpriteUrl = "/img/testchar.svg" };
            Character Branson = new Character { CharacterId = 2, Name = "Branson", SpriteUrl = "/img/testchar.svg" };
            Character Cornelius = new Character { CharacterId = 3, Name = "Cornelius", SpriteUrl = "/img/testchar.svg" };
            Character Drew = new Character { CharacterId = 4, Name = "Drew", SpriteUrl = "/img/testchar.svg" };

            _context.Add(Alfonse);
            _context.Add(Branson);
            _context.Add(Cornelius);
            _context.Add(Drew);
        }
    }
}
