using Encounter.Entities;
using System.Collections.Generic;

namespace Encounter.ViewModels
{
    public class AbilityPageViewModel
    {
        public Player CurrentPlayer { get; set; }
        //public Game CurrentGame { get; set; }
        //public Character SelectedCharacter { get; set; }
        public IEnumerable<Ability> Abilities { get; set; }
    }
}