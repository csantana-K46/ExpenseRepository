using carlos.expense.core.FakeRepository;
using carlos.expense.core.Model;
using System.Web.Mvc;
using MyExpenseManager.Controllers;
using MyExpenseManager.Models;
using Should;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace carlos.expense.specs.Steps
{
    [Binding]
    public class RegisterExpenseCategorySteps
    {
        FakeCategoryRepository fakeCategoryRepository = new FakeCategoryRepository();

        [Given(@"I have entered the category information")]
        public void GivenIHaveEnteredTheCategoryInformation(Table table)
        {
            var controller = new CategoryController(fakeCategoryRepository);
            ScenarioContext.Current["controller"] = controller;
            ScenarioContext.Current["table"] = table;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var controller = (CategoryController)ScenarioContext.Current["controller"];
            var table = (Table)ScenarioContext.Current["table"];
            var instanceTable = table.CreateInstance<Category>();
            var viewModel = new CategoryViewModel
            {
                Id = instanceTable.Id,
                Name = instanceTable.Name
            };
            ScenarioContext.Current.Set(controller.RegisterCategory(viewModel), "message");
        }
        
        [Then(@"the result should see a message Category successfully added")]
        public void ThenTheResultShouldSeeAMessageCategorySuccessfullyAdded()
        {
            var message = (ViewResult)ScenarioContext.Current["message"];
            message.TempData["message"].ToString().ShouldEqual("Category successfully added");
        }
    }
}
