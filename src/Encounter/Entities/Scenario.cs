using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Encounter.Entities
{
    public class Scenario
    {
        [Key]
        public int ScenarioId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}