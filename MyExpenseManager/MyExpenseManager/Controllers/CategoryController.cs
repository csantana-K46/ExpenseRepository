using System;
using System.Web.Mvc;
using carlos.expense.core.IRepository;
using carlos.expense.core.Model;
using MyExpenseManager.Models;

namespace MyExpenseManager.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View(_repository.GetCategories());
        }

        public ActionResult RegisterCategory()
        {
            return View(new CategoryViewModel{});
        }

      
        [HttpPost]
        public ActionResult RegisterCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid) //check for any validation errors
            {
                var category = new Category
                {
                    Id = categoryViewModel.Id,
                    Name = categoryViewModel.Name,
                    CreationDate = DateTime.Now,
                };
                _repository.RegisterCategory(category);
                _repository.CategorySave();
                TempData["message"] = "Category successfully added";
                return View("Success");
            }
            else
            {
                return View(categoryViewModel);
            }
        }
    }
}
