using Encounter.Entities;
using System.Collections.Generic;

namespace Encounter.ViewModels
{
    public class GamePageViewModel
    {
        public Player CurrentPlayer { get; set; }
        public Character SelectedCharacter { get; set; }
    }
}