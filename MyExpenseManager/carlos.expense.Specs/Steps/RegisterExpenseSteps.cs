using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using carlos.expense.core.FakeRepository;
using carlos.expense.core.Model;
using carlos.expense.specs.Utils;
using MyExpenseManager.Controllers;
using MyExpenseManager.Models;
using NUnit.Framework;
using Should;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace carlos.expense.specs.Steps
{
    [Binding]
    public class RegisterExpenseSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        FakeExpenseRepository fakeExpenseRepository = new FakeExpenseRepository();


        [When(@"I register an expense with the following data:")]
        public void WhenIRegisterAnExpenseWithTheFollowingData(Table table)
        {
            var controller = new ExpenseController(fakeExpenseRepository);
            controller.CategoryRepository = new FakeCategoryRepository();
 
            var instanceTable = table.CreateInstance<TableSpec>();
            var categories = controller.CategoryRepository.GetCategories();
            instanceTable.Category = (Category)ScenarioContext.Current["category"];

            var viewModel = new ExpenseViewModel
            {
                Amount = instanceTable.Amount,
                RegisterDate = instanceTable.RegisterDate,
                Categories = categories,
                Category = instanceTable.Category,
                SelectedValue = instanceTable.CategoryId
            };
            ScenarioContext.Current.Set(viewModel, "viewModel");
            ScenarioContext.Current.Set(controller.RegisterExpense(viewModel), "viewResult");
        }

        [Then(@"the last expense registed should match:")]
        public void ThenTheLastExpenseRegistedShouldMatch(Table table)
        {
            var instanceTable = table.CreateInstance<TableSpec>();
            instanceTable.Category = (Category)ScenarioContext.Current["category"];
            var viewModel = (ExpenseViewModel)ScenarioContext.Current["viewModel"];
            Assert.AreEqual(instanceTable.Amount,viewModel.Amount);
            Assert.AreEqual(instanceTable.Category, viewModel.Category);
            Assert.AreEqual(instanceTable.RegisterDate, viewModel.RegisterDate);

        }


     

      
    }
}
