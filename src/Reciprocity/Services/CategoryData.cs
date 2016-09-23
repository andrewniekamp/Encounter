using Reciprocity.Entities;
using System.Collections.Generic;

namespace Reciprocity.Services
{
    public interface ICategoryData
    {
        IEnumerable<Category> GetAll();
    }
    public class InMemoryCategoryData : ICategoryData
    {
        public InMemoryCategoryData()
        {
            _categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Dessert" },
                new Category { CategoryId = 2, Name = "Lunch" },
                new Category { CategoryId = 3, Name = "Snacks" }
            };
        }

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        List<Category> _categories;
    }
}
