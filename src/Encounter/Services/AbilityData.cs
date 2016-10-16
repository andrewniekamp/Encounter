using Encounter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface IAbilityData
    {
        IEnumerable<Ability> GetAll();
        Ability Get(int id);
        void Add(Ability newAbility);
        void Generate();
    }

    public class SqlAbilityData : IAbilityData
    {
        private EncounterDbContext _context;
        
        public SqlAbilityData(EncounterDbContext context)
        {
            _context = context;
        }
        public void Add(Ability newAbility)
        {
            _context.Add(newAbility);
            _context.SaveChanges();
        }

        public void Generate()
        {
            if (!_context.Abilities.Any())
            {
                _context.Add(new Ability { Name = "Hammer Blow", FoeHarm = 3, ImageUrl = "/img/actions/hammer-blow.png", CoolDownMiliSecs = 1800 });
                _context.Add(new Ability { Name = "Heal", CharHeal = 2, ImageUrl = "/img/actions/heal.png", CoolDownMiliSecs = 2000 });

                _context.Add(new Ability { Name = "Piercing Arrow", FoeHarm = 4, ImageUrl = "/img/actions/piercing-arrow.png", CoolDownMiliSecs = 2300 });
                _context.Add(new Ability { Name = "Shove", FoeHarm = 1, ImageUrl = "/img/actions/shove.png", CoolDownMiliSecs = 500 });

                _context.Add(new Ability { Name = "Stab", FoeHarm = 4, ImageUrl = "/img/actions/stab.png", CoolDownMiliSecs = 2300 });
                _context.Add(new Ability { Name = "Snide Remark", FoeHarm = 1, ImageUrl = "/img/actions/snide-remark.png", CoolDownMiliSecs = 500 });

                _context.Add(new Ability { Name = "Mysterious Chant", CharHeal = 2, CharHarm = 1, ImageUrl = "/img/actions/inspiring-speech.png", CoolDownMiliSecs = 2000 });
                _context.Add(new Ability { Name = "Intense Glare", FoeHarm = 2, ImageUrl = "/img/actions/belittling-glare.png", CoolDownMiliSecs = 1500 });

                _context.Add(new Ability { Name = "Heal 2", CharHeal = 4, ImageUrl = "/img/actions/heal.png", CoolDownMiliSecs = 3000 });
                _context.Add(new Ability { Name = "Claw Attack", FoeHarm = 3, ImageUrl = "/img/actions/claw-attack.png", CoolDownMiliSecs = 2000 });
                _context.Add(new Ability { Name = "Rude Remark", FoeHarm = 1, ImageUrl = "/img/actions/snide-remark.png", CoolDownMiliSecs = 2000 });
                _context.Add(new Ability { Name = "Salty Insult", FoeHarm = 2, ImageUrl = "/img/actions/heal.png", CoolDownMiliSecs = 1800 });
                _context.Add(new Ability { Name = "Bite", FoeHarm = 4, ImageUrl = "/img/actions/claw-attack.png", CoolDownMiliSecs = 1800 });

                _context.SaveChanges();
            }
        }

        public Ability Get(int id)
        {
            return _context.Abilities.FirstOrDefault(c => c.AbilityId == id);
        }

        public IEnumerable<Ability> GetAll()
        {
            return _context.Abilities.ToList();
        }
    }
}
