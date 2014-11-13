using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using carlos.expense.core.IRepository;
using carlos.expense.core.Model;

namespace carlos.expense.core.FakeRepository
{
   public class FakeExpenseRepository : IExpenseRepository
    {
        public IList<Expense> Expenses = new List<Expense>
         {
                new Expense
                {
                    Id = 1,
                    Amount = 200.00m,
                    CategoryId = 1,
                    Category = new Category {Id = 1, Name = "Food"},
                    RegisterDate = new DateTime(2014, 01, 10)
                },

                new Expense
                {
                    Id = 2,
                    Amount = 230.00m,
                    CategoryId = 1,
                    Category = new Category {Id = 1, Name = "Food"},
                    RegisterDate = new DateTime(2014, 01, 10)
                },
                new Expense
                {
                    Id = 3,
                    Amount = 400.00m,
                    CategoryId = 2,
                    Category = new Category {Id = 2, Name = "Dreess"},
                    RegisterDate = new DateTime(2014, 02, 10)
                },
                new Expense
                {
                    Id = 4,
                    Amount = 200.00m,
                    CategoryId = 2,
                    Category = new Category {Id = 2, Name = "Dress"},
                    RegisterDate = new DateTime(2014, 03, 10)
                },
                new Expense
                {
                    Id = 5,
                    Amount = 45600.00m,
                    CategoryId = 1,
                    Category = new Category {Id = 1, Name = "Food"},
                    RegisterDate = new DateTime(2014, 04, 10)
                },
                new Expense
                {
                    Id = 6,
                    Amount = 4000.00m,
                    CategoryId = 3,
                    Category = new Category {Id = 3, Name = "Transport"},
                    RegisterDate = new DateTime(2014, 04, 10)
                },
                new Expense
                {
                    Id = 7,
                    Amount = 4000.00m,
                    CategoryId = 3,
                    Category = new Category {Id = 3, Name = "Transport"},
                    RegisterDate = new DateTime(2014, 04, 10)
                },
               
            };
        private bool _submitExpenseSave = false;

        public void RegisterExpense(Expense expense)
        {
            Expenses.Add(expense);
        }

        public IList<Expense> GetExpenses()
        {
            return Expenses;
        }

        public void ExpenseSave()
        {
            _submitExpenseSave = true;
        }

        public IList<Expense> ViewExpensesSummaryByCategory()
        {
            var expensesSummary = Expenses
                .GroupBy(ac => new
                {
                    ac.CategoryId,
                    ac.RegisterDate
                })
                .Select(ac => new Expense
                {
                    Category = (from cat in Expenses
                                where cat.CategoryId == ac.Key.CategoryId
                                select cat.Category).First(),
                    CategoryId = ac.Key.CategoryId,
                    RegisterDate = ac.Key.RegisterDate,
                    Amount = ac.Sum(acs => acs.Amount)
                }).OrderBy(expense => expense.Amount).ToList();
            return expensesSummary;
        }

        public List<Expense> ViewExpensesHistory(DateTime fromDate, DateTime toDate)
        {
            var expensesHistory = Expenses
                .Where(ac => ac.RegisterDate >= fromDate && ac.RegisterDate <= toDate)
               .Select(ac => new Expense
               {
                   Id = ac.Id,
                   Category = ac.Category,
                   CategoryId = ac.CategoryId,
                   RegisterDate = ac.RegisterDate,
                   Amount = ac.Amount
               }).ToList();
            return expensesHistory;
        }
    }
}
