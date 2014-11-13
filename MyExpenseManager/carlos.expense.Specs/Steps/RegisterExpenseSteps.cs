using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using carlos.expense.core.FakeRepository;
using carlos.expense.core.Model;
using MyExpenseManager.Controllers;
using MyExpenseManager.Models;
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

        [Given(@"I have entered expense money for this Expense:")]
        public void GivenIHaveEnteredExpenseMoneyForThisExpense(Table table)
        {
    
            var controller = new ExpenseController(fakeExpenseRepository);
            controller.CategoryRepository = new FakeCategoryRepository();
            ScenarioContext.Current["controller"] = controller;
            ScenarioContext.Current["table"] = table;
           
        }

        [When(@"I press the add button")]
        public void WhenIPressTheAddButton()
        {
            var controller = (ExpenseController)ScenarioContext.Current["controller"];
            var table = (Table) ScenarioContext.Current["table"];
            var instanceTable = table.CreateInstance<Expense>();
            var categories = controller.CategoryRepository.GetCategories();
            var category = controller.CategoryRepository.GetCategoryById(instanceTable.CategoryId);
            var viewModel = new ExpenseViewModel{
                Id = instanceTable.Id,
                Amount = instanceTable.Amount,
                RegisterDate = instanceTable.RegisterDate,
                Categories = categories,
                Category = category,
                SelectedValue = instanceTable.CategoryId
            };
            ScenarioContext.Current.Set(controller.RegisterExpense(viewModel),"actionResult");
        }

        [Then(@"the user should see a message Expense successfully added")]
        public void ThenTheUserShouldSeeAMessageExpenseSuccessfullyAdded()
        {
            var actionResult = (ViewResult)ScenarioContext.Current["actionResult"];
            actionResult.TempData["message"].ToString().ShouldEqual("Expense successfully added");
            
        }

     

      
    }
}
