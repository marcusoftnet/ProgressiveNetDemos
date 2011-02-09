using System;
using System.Collections.Generic;
using System.Linq;
using Should.Fluent;
using Specs.TestEntities;
using TechTalk.SpecFlow;

namespace Specs.Tables
{
    [Binding]
    public class TableSteps
    {
        private const string RESULT_KEY = "Result";

        [Given("I have the following persons")]
        public void IHaveTheFollowingPersons(Table personsTable)
        {
            var persons = personsTable.Rows
                    .Select(row => 
                            new Person{
                                  Name = row["Name"], 
                                  BirthDate = DateTime.Parse(row["Birth date"]), 
                                  Style = (Style) Enum.Parse(typeof (Style), row["Style"])}).ToList();

            ScenarioContext.Current.Set(persons);
        }

        [When("I search for (.*)")]
        public void ISearchFor(string nameToSearchFor)
        {
            var list = ScenarioContext.Current.Get<List<Person>>();

            var result = list.Where(x => x.Name == nameToSearchFor).ToList();

            ScenarioContext.Current.Set(result, RESULT_KEY);
        }

        [Then("the following person should be returned")]
        public void ThenTheResultShouldBe(Table resultTable)
        {
            var result = ScenarioContext.Current.Get<List<Person>>(RESULT_KEY);

            resultTable.Rows.Count.Should().Equal(1);
            resultTable.Rows[0]["Name"].Should().Equal(result[0].Name);
        }
    }
}
