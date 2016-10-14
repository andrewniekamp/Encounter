using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encounter.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string PlayerName { get; set; }
        public bool Authorized { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
