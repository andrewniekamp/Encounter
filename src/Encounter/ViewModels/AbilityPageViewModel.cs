using Encounter.Entities;
using System.Collections.Generic;

namespace Encounter.ViewModels
{
    public class AbilityPageViewModel
    {
        public ApplicationUser User { get; set; }
        public Character Character { get; set; }
        public IEnumerable<Ability> Abilities { get; set; }
    }
}