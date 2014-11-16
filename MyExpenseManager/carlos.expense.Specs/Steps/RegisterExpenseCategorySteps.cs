using carlos.expense.core.FakeRepository;
using carlos.expense.core.Model;
using System.Web.Mvc;
using MyExpenseManager.Controllers;
using MyExpenseManager.Models;
using NUnit.Framework;
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
                Name = instanceTable.Name
            };
            ScenarioContext.Current.Set(viewModel,"viewModel");
            ScenarioContext.Current.Set(controller.RegisterCategory(viewModel), "viewResult");
        }

        [Then(@"it should notify '(.*)'")]
        public void ThenItShouldNotify(string p0)
        {
            var viewResult = (ViewResult)ScenarioContext.Current["viewResult"];
            viewResult.TempData["message"].ToString().ShouldEqual(p0);
        }

        [Then(@"the last category registered should match:")]
        public void ThenTheLastCategoryRegisteredShouldMatch(Table table)
        {
            var instanceTable = table.CreateInstance<Category>();
            var viewModel = (CategoryViewModel)ScenarioContext.Current["viewModel"];
            Assert.AreEqual(instanceTable.Name,viewModel.Name);
        }

    }
}
