using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public Game GameInstance { get; set; }
        //public IEnumerable<Game> GameHistory { get; set; }
    }
}