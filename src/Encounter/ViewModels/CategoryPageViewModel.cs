using Encounter.Entities;
using System.Collections.Generic;

namespace Encounter.ViewModels
{
    public class CategoryPageViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public string CurrentGreeting { get; set; }
    }
}
