using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Entities
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string SpriteUrl { get; set; }
        public int Health { get; set; }
        public ICollection<Ability> Abilities { get; set; }
    }
}
