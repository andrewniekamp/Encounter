using Encounter.Entities;
using System.Collections.Generic;
using static Encounter.Services.SqlGameData;

namespace Encounter.ViewModels
{
    public class CharacterPageViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<Character> Characters { get; set; }
    }
}
