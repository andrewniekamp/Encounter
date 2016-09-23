using Microsoft.AspNetCore.Mvc;
using Reciprocity.Models;
using Reciprocity.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Reciprocity.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryData _categoryData;

        public CategoriesController(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _categoryData.GetAll();
            return View(model);
        }
    }
}
