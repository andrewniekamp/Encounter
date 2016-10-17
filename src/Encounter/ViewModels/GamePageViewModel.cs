using Encounter.Entities;
using System.Collections.Generic;

namespace Encounter.ViewModels
{
    public class GamePageViewModel
    {
        public Game Game { get; set; }
        public Character Character { get; set; }
        public Event CurrentEvent { get; set; }
        public bool LastEvent { get; set; }
        public ICollection<Event> RemainingEvents { get; set; }
        public int EventsCompleted { get; set; }
    }
}