using Should.Fluent;
using Specs.TestEntities;
using TechTalk.SpecFlow;

namespace Specs._031ScenarioContext
{
    [Binding]
    public class ScenarioContextSteps
    {

        [When(@"I store a person called (.*) in the ScenarioContext.Current")]
        public void StorePersonInScenarioContext(string personName)
        {
            var p = new Person { Name = personName };
            ScenarioContext.Current.Set<Person>(p);
            ScenarioContext.Current.Set(p, "PersonKey");
        }

        [Then("a person called (.*) can easily be retrieved")]
        public void RetrieveFromScenarioContext(string personName)
        {
            var pByType = ScenarioContext.Current.Get<Person>();
            pByType.Should().Not.Be.Null();


            var pByKey = ScenarioContext.Current["PersonKey"] as Person;
            pByKey.Should().Not.Be.Null();
        }
    }
}
