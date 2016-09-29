using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Entities
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public DateTime DateCreated { get; set; }
        public ApplicationUser User { get; set; }
        public Character Character { get; set; }
        //public ICollection<Encounter> Encounters { get; set; }
    }
}
