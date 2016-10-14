using System;
using System.ComponentModel.DataAnnotations;

namespace Encounter.Entities
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public Game GameInstance { get; set; }
        public ApplicationUser User { get; set; }
    }
}