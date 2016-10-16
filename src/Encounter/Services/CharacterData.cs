using Encounter.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public void Generate()
        {
            if (!_context.Characters.Any())
            {
                _context.Add(new Character
                {
                    Name = "Winterberry",
                    SpriteUrl = "/img/char/cleric.png",
                    Class = "Cleric",
                    Health = 20,
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Hammer Blow"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Heal"),
                    //Ability3 = _context.Abilities.FirstOrDefault(a => a.Name == "Hammer Blow"),
                });
                _context.Add(new Character
                {
                    Name = "Clementine",
                    SpriteUrl = "/img/char/ranger.png",
                    Class = "Ranger",
                    Health = 20,
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Piercing Arrow"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Shove"),
                    //Ability3 = _context.Abilities.FirstOrDefault(a => a.Name == "Hammer Blow"),
                });
                _context.Add(new Character
                {
                    Name = "Alfonse",
                    SpriteUrl = "/img/char/rogue.png",
                    Class = "Rogue",
                    Health = 18,
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Stab"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Snide Remark"),
                    //Ability3 = _context.Abilities.FirstOrDefault(a => a.Name == "Hammer Blow"),
                });
                _context.Add(new Character
                {
                    Name = "Veda",
                    SpriteUrl = "/img/char/demon-hunter.png",
                    Class = "Demon Hunter",
                    Health = 18,
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Intense Glare"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Mysterious Chant"),
                    //Ability3 = _context.Abilities.FirstOrDefault(a => a.Name == "Hammer Blow"),
                });

                _context.SaveChanges();
            }
        }

        public Character Get(int id)
        {
            return _context.Characters
                .Include(c => c.Ability1)
                .Include(c => c.Ability2)
                .Include(c => c.Ability3)
                .FirstOrDefault(c => c.CharacterId == id);
        }

        public IEnumerable<Character> GetAll()
        {
            return _context.Characters.ToList();
        }
    }
}
