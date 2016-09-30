using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Entities
{
    public class Foe
    {
        [Key]
        public int FoeId { get; set; }
        public string Name { get; set; }
        public string SpriteUrl { get; set; }
        public int Health { get; set; }
        ICollection<Ability> Abilities { get; set; }
        public Event Event { get; set; }
    }
}