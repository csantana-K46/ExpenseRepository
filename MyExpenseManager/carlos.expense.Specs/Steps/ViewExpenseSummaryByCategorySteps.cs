using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using carlos.expense.core.FakeRepository;
using carlos.expense.core.Model;
using carlos.expense.specs.Utils;
using MyExpenseManager.Controllers;
using MyExpenseManager.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Should.Core.Assertions;
using NUnit.Framework;
using Assert = Should.Core.Assertions.Assert;

namespace carlos.expense.specs.Steps
{
    [Binding]
    public class ViewExpenseSummaryByCategorySteps
    {
        FakeExpenseRepository  fakeExpenseRepository = new FakeExpenseRepository();

        [Given(@"I have an expenses stored")]
        public void GivenIHaveAnExpensesStored()
        {
            var controller = new ExpenseController(fakeExpenseRepository);
            ScenarioContext.Current["controller"] = controller;
        }
        [When(@"I press search ""(.*)""")]
        public void WhenIPressSearch(string p0)
        {
            var controller = (ExpenseController)ScenarioContext.Current["controller"];
            ViewResult actionController;

            if(p0 == "Summary")
            {
                actionController = controller.ViewExpensesSummaryByCategory();
            }
            else
            {
                var fromDate = (DateTime)ScenarioContext.Current["fromDate"];
                var toDate = (DateTime)ScenarioContext.Current["toDate"];
                var viewModel = new ExpenseHistoryViewModel {FromDate = fromDate,ToDate = toDate};
                actionController = controller.ViewExpensesHistory(viewModel);
            }
            ScenarioContext.Current["result"] = actionController;
        }

        
        [Then(@"the result should be the next set of data:")]
        public void ThenTheResultShouldBeTheNextSetOfData(Table table)
        {
            var tableSpec = table.CreateSet<TableSpec>();
            var result = (ViewResult) ScenarioContext.Current["result"];
            foreach (var expenseSpec in tableSpec)
            {
                TableSpec spec = expenseSpec;
                var amount = from queryResult in (List<Expense>) result.Model
                             where queryResult.CategoryId == spec.CategoryId && queryResult.RegisterDate == spec.RegisterDate
                             select queryResult.Amount;

                Assert.Equal(expenseSpec.Amount, amount.First());
                
            }
        }
    }
}
