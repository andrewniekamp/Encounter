using Reciprocity.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Reciprocity.Services
{
    public interface ICategoryData
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
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

        public Category Get(int id)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == id);
        }

        List<Category> _categories;
    }
}
