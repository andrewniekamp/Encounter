﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Encounter.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Game Game { get; set; }
        public Foe Foe { get; set; }
    }
}