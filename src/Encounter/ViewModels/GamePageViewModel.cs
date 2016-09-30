using Encounter.Entities;
using System.Collections.Generic;

namespace Encounter.ViewModels
{
    public class GamePageViewModel
    {
        public ApplicationUser User { get; set; }
        public Game Game { get; set; }
        public Character Character { get; set; }
        public ICollection<Ability> Abilities { get; set; }
        //public Encounter Encounter { get; set; }
        //public Foe Foe { get; set; }
    }
}