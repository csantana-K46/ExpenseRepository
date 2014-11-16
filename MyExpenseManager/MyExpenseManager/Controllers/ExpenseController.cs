using System.Web.Mvc;
using carlos.expense.core.IRepository;
using carlos.expense.core.Model;
using MyExpenseManager.Models;
using Ninject;

namespace MyExpenseManager.Controllers
{
    public class ExpenseController: Controller
    {
        private readonly IExpenseRepository _repository;
        [Inject]
        public ICategoryRepository CategoryRepository { get; set; }

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            // TODO: Complete member initialization
            _repository = expenseRepository;
        }

        public ActionResult Index()
        {
            return View(_repository.GetExpenses());
        }

        [HttpGet]
        public ActionResult RegisterExpense()
        {
            var expenseCategories = CategoryRepository.GetCategories();
            var expenseViewModel = new ExpenseViewModel {Categories = expenseCategories};
            return View(expenseViewModel);

        }
        [HttpPost]
        public ActionResult RegisterExpense(ExpenseViewModel expenseViewModel)
        {
            if (ModelState.IsValid) //check for any validation errors
            {
                var category = CategoryRepository.GetCategoryById(expenseViewModel.SelectedValue);
                var expense = new Expense{
                    Amount = expenseViewModel.Amount,
                    Category = category,
                    RegisterDate = expenseViewModel.RegisterDate
                };
                _repository.RegisterExpense(expense);
                _repository.ExpenseSave();
                TempData["message"] = "Expense registered successfully";
                return View("success");
            }
           
            //when validation failed return viewmodel back to UI.
            return View(expenseViewModel);
            
         
        }


        public ViewResult ViewExpensesSummaryByCategory()
        {
            var viewExpensesSummaryByCategory = _repository.ViewExpensesSummaryByCategory();
            return View(viewExpensesSummaryByCategory);
        }

        [HttpGet]
        public ViewResult ViewExpensesHistory()
        {
            return View("ViewExpensesHistorySearch",new ExpenseHistoryViewModel());
        }

        [HttpPost]
        public ViewResult ViewExpensesHistory(ExpenseHistoryViewModel model)
        {
            if (ModelState.IsValid)
            {
             var viewExpensesHistory = _repository.ViewExpensesHistory(model.FromDate,model.ToDate);
             return View("ViewExpensesHistory", viewExpensesHistory);
            }

            return View("ViewExpensesHistorySearch", model);

        }
    }
}
