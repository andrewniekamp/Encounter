using Microsoft.AspNetCore.Mvc;
using Encounter.ViewModels;
using Encounter.Services;
using Encounter.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Encounter.Controllers
{
    public class PlayerController : Controller
    {
        private IGreeter _greeter;
        private ICategoryData _categoryData;
        private IPlayerData _playerData;

        public PlayerController(
            ICategoryData categoryData,
            IPlayerData playerData,
            IGreeter greeter)
        {
            _categoryData = categoryData;
            _playerData = playerData;
            _greeter = greeter;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new PlayerPageViewModel();
            model.Categories = _categoryData.GetAll();
            model.Players = _playerData.GetAll();
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
            var model = _playerData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Game(int id)
        {
            var model = _playerData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
