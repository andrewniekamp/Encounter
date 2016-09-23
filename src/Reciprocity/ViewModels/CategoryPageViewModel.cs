using Reciprocity.Entities;
using System.Collections.Generic;

namespace Reciprocity.ViewModels
{
    public class CategoryPageViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public string CurrentGreeting { get; set; }
    }
}
