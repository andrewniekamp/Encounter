using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Encounter.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string ImageUrl { get; set; }
        public Scenario Scenario { get; set; }
        public Foe Foe { get; set; }
        public Game Game { get; set; }
    }
}