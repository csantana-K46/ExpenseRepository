using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using carlos.expense.core.Model;

namespace carlos.expense.core.IRepository
{
    public interface IExpenseRepository
    {
        void RegisterExpense(Expense expense);
        IList<Expense> GetExpenses();
        IList<Expense> ViewExpensesSummaryByCategory();
        List<Expense> ViewExpensesHistory(DateTime fromDate, DateTime toDate);
        void ExpenseSave();
    }
}
