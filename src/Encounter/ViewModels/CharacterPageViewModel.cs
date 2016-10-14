using Encounter.Entities;
using System.Collections.Generic;
using static Encounter.Services.SqlGameData;

namespace Encounter.ViewModels
{
    public class CharacterPageViewModel
    {
        public ApplicationUser User { get; set; }
        public Character SelectedCharacter { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Scenario> Scenarios { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Ability> Abilities { get; set; }
    }
}
