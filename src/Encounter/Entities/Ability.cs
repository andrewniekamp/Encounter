using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Entities
{
    public class Ability
    {
        [Key]
        public int AbilityId { get; set; }
        public string Name { get; set; }
        public int CoolDownMiliSecs { get; set; }
        public string ImageUrl { get; set; }
        public int CharHeal { get; set; }
        public int CharHarm { get; set; }
        public int FoeHeal { get; set; }
        public int FoeHarm { get; set; }
    }
}
