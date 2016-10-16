using Encounter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface IEventData
    {
        IEnumerable<Event> GetAll();
        Event Get(int id);
        void Add(Event newEvent);
        ICollection<Event> Generate(int scenarioId);
    }

    public class SqlEventData : IEventData
    {
        private EncounterDbContext _context;

        public SqlEventData(EncounterDbContext context)
        {
            _context = context;
        }
        public void Add(Event newEvent)
        {
            _context.Add(newEvent);
            _context.SaveChanges();
        }

        public ICollection<Event> Generate(int scenarioId)
        {
            Scenario scenario = _context.Scenarios.FirstOrDefault(s => s.ScenarioId == scenarioId);
            List<Event> events = new List<Event>();

            if (scenario.Name == "Forest")
            {
                events.Add(new Event { Name = "Forest 1", Level = 1, ImageUrl = "/img/events/forest1.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 1).Take(1).First(), Scenario = scenario });
                events.Add(new Event { Name = "Forest 2", Level = 2, ImageUrl = "/img/events/forest2.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 2).Take(1).First(), Scenario = scenario });
                events.Add(new Event { Name = "Forest 3", Level = 3, ImageUrl = "/img/events/forest3.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 3).Take(1).First(), Scenario = scenario });
            }
            else if (scenario.Name == "Desert")
            {
                events.Add(new Event { Name = "Desert 1", Level = 1, ImageUrl = "/img/events/desert1.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 1).Take(1).First(), Scenario = scenario });
                events.Add(new Event { Name = "Desert 2", Level = 2, ImageUrl = "/img/events/desert2.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 2).Take(1).First(), Scenario = scenario });
                events.Add(new Event { Name = "Desert 3", Level = 3, ImageUrl = "/img/events/desert3.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 3).Take(1).First(), Scenario = scenario });
            }
            else if (scenario.Name == "Lair")
            {
                events.Add(new Event { Name = "Lair 1", Level = 1, ImageUrl = "/img/events/lair1.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 1).Take(1).First(), Scenario = scenario });
                events.Add(new Event { Name = "Lair 2", Level = 2, ImageUrl = "/img/events/lair2.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 2).Take(1).First(), Scenario = scenario });
                events.Add(new Event { Name = "Lair 3", Level = 3, ImageUrl = "/img/events/lair3.jpg", Foe = _context.Foes.OrderBy(r => Guid.NewGuid()).Where(f => f.Scenario.Name == scenario.Name && f.Level == 3).Take(1).First(), Scenario = scenario });
            }
            return events;
        }

        public Event Get(int id)
        {
            return _context.Events
                .Include(e => e.Scenario)
                .Include(e => e.Foe).ThenInclude(f => f.Ability1)
                .Include(e => e.Foe).ThenInclude(f => f.Ability2)
                .Include(e => e.Foe).ThenInclude(f => f.Ability3)
                .FirstOrDefault(c => c.EventId == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events.ToList();
        }
    }
}
