using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.DAL.Interface;

namespace ShopApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryDb categoryDb;

        public CategoryController(ICategoryDb CategoryDb) 
        {
            this.categoryDb = CategoryDb;
        }

        // GET: CategoryController1
        public ActionResult Index()
        {
            var categories = categoryDb.GetCategories();
            return View(categories);
        }

        // GET: CategoryController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
