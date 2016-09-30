using Encounter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface IFoeData
    {
        IEnumerable<Foe> GetAll();
        Foe Get(int id);
        void Add(Foe newFoe);
    }

    public class SqlFoeData : IFoeData
    {
        private EncounterDbContext _context;

        public SqlFoeData(EncounterDbContext context)
        {
            _context = context;
        }
        public void Add(Foe newFoe)
        {
            _context.Add(newFoe);
            _context.SaveChanges();
        }

        public Foe Get(int id)
        {
            return _context.Foes.FirstOrDefault(c => c.FoeId == id);
        }

        public IEnumerable<Foe> GetAll()
        {
            return _context.Foes.ToList();
        }
    }
}
