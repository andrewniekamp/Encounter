using Encounter.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Encounter.Services
{
    public interface IScenarioData
    {
        IEnumerable<Scenario> GetAll();
        Scenario Get(int id);
        void Add(Scenario newScenario);
        void Generate();
        Scenario Demo();
    }

    public class SqlScenarioData : IScenarioData
    {
        private EncounterDbContext _context;

        public SqlScenarioData(EncounterDbContext context)
        {
            _context = context;
        }
        public void Add(Scenario newScenario)
        {
            _context.Add(newScenario);
            _context.SaveChanges();
        }

        public Scenario Demo()
        {
            return _context.Scenarios
                .Include(s => s.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability1)
                .Include(s => s.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability2)
                .Include(s => s.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability3)
                .FirstOrDefault(s => s.Name == "Lair");
        }

        public void Generate()
        {
            if (!_context.Scenarios.Any())
            {
                _context.Add(new Scenario { Name = "Forest", IconUrl = "/img/scenarios/forest.png" });
                _context.Add(new Scenario { Name = "Desert", IconUrl = "/img/scenarios/desert.png" });
                _context.Add(new Scenario { Name = "Lair", IconUrl = "/img/scenarios/lair.png" });

                _context.SaveChanges();
            }
        }

        public Scenario Get(int id)
        {
            return _context.Scenarios
                .Include(s => s.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability1)
                .Include(s => s.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability2)
                .Include(s => s.Events).ThenInclude(e => e.Foe).ThenInclude(f => f.Ability3)
                .FirstOrDefault(s => s.ScenarioId == id);
        }

        public IEnumerable<Scenario> GetAll()
        {
            return _context.Scenarios.ToList();
        }
    }
}
