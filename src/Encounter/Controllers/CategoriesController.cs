using Microsoft.AspNetCore.Mvc;
using Encounter.ViewModels;
using Encounter.Services;
using Encounter.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Encounter.Controllers
{
    public class CategoriesController : Controller
    {
        private IGreeter _greeter;
        private ICategoryData _categoryData;

        public CategoriesController(
            ICategoryData categoryData,
            IGreeter greeter)
        {
            _categoryData = categoryData;
            _greeter = greeter;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new CategoryPageViewModel();
            model.Categories = _categoryData.GetAll();
            model.CurrentGreeting = _greeter.GetGreeting();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryEditViewModel model)
        {
            var category = new Category();
            category.Name = model.Name;

            _categoryData.Add(category);

            return RedirectToAction("Details", new { id = category.CategoryId });

        }

        public IActionResult Details(int id)
        {
            var model = _categoryData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
