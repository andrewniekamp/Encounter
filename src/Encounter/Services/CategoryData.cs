using Encounter.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Encounter.Services
{
    public interface ICategoryData
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Add(Category newCategory);
    }

    public class SqlCategoryData : ICategoryData
    {
        private EncounterDbContext _context;

        public SqlCategoryData(EncounterDbContext context)
        {
            _context = context;
        }
        public void Add(Category newCategory)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
        }

        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
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
