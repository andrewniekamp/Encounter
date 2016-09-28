using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Entities
{
    public class Ability
    {
        public int AbilityId { get; set; }
        public string Name { get; set; }
        public virtual Character Character { get; set; }
        //public virtual IEnumerable<Modifier> Modifiers { get; set; }
    }
}
