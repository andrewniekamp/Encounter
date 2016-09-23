using Reciprocity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Reciprocity.Services
{
    public interface ICategoryData
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Add(Category newCategory);
    }
    public class InMemoryCategoryData : ICategoryData
    {
        static InMemoryCategoryData()
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

        public Category Get(int id)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public void Add(Category newCategory)
        {
            newCategory.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            _categories.Add(newCategory);
        }

        static List<Category> _categories;
    }
}
