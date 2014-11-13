using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using carlos.expense.core.Model;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Assert = Should.Core.Assertions.Assert;

namespace carlos.expense.specs.Steps
{
    [Binding]
    public class ViewExpenseHistorySteps
    {
        [Given(@"I have entered ""(.*)"" and ""(.*)"" dates")]
        public void GivenIHaveEnteredAndDates(DateTime fromDate, DateTime toDate)
        {
            ScenarioContext.Current["fromDate"] = fromDate;
            ScenarioContext.Current["toDate"] = toDate;
        }
        
        [Then(@"the result should be a list with my expenses:")]
        public void ThenTheResultShouldBeAListWithMyExpenses(Table table)
        {
            var tableSpec = table.CreateSet<Expense>();
            var result = (ViewResult)ScenarioContext.Current["result"];
            foreach (var expenseSpec in tableSpec)
            {
                Expense spec = expenseSpec;
                var expenseQuery = (from expResult in (List<Expense>)result.Model
                             where expResult.Id == spec.Id
                             select expResult).First();

                Assert.Equal(expenseSpec.Id, expenseQuery.Id);
                Assert.Equal(expenseSpec.RegisterDate, expenseQuery.RegisterDate);
                Assert.Equal(expenseSpec.Amount, expenseQuery.Amount);

            }
        }
    }
}
