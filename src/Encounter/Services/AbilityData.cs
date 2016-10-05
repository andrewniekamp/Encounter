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
