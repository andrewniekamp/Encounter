using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Entities
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string SpriteUrl { get; set; }
        //public IEnumerable<Encounter> Encounters { get; set; }
        public IEnumerable<Ability> Abilities { get; set; }
        //public IEnumerable<Stat> Stats { get; set; }
    }
}
