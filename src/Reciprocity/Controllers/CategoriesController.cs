using Microsoft.AspNetCore.Mvc;
using Reciprocity.ViewModels;
using Reciprocity.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Reciprocity.Controllers
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
