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

        public Event Get(int id)
        {
            return _context.Events
                .Include(e => e.Foe)
                .ThenInclude(f => f.Abilities)
                .FirstOrDefault(c => c.EventId == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events.ToList();
        }
    }
}
