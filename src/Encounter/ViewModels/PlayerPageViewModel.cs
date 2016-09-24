using Encounter.Entities;
using System.Collections.Generic;

namespace Encounter.ViewModels
{
    public class PlayerPageViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public string CurrentGreeting { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Character> Characters { get; set; }
    }
}
