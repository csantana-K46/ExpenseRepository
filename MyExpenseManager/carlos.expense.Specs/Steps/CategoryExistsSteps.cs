using carlos.expense.core.FakeRepository;
using TechTalk.SpecFlow;

namespace carlos.expense.Specs.Steps
{
    [Binding]
    public class CategoryExistsSteps
    {
        FakeCategoryRepository fakeCategoryRepository = new FakeCategoryRepository();

        [Given(@"the category ""(.*)"" exists")]
        public void GivenTheCategoryExists(string categoryName)
        {

            ScenarioContext.Current.Set(fakeCategoryRepository.GetCategoryByNAme(categoryName),"category");
        }
    }
}
