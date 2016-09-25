using Encounter.Entities;
using System.Collections.Generic;
using static Encounter.Services.SqlGameData;

namespace Encounter.ViewModels
{
    public class CharacterPageViewModel
    {
        public Player Player { get; set; }
        public IEnumerable<Character> Characters { get; set; }
    }
}
