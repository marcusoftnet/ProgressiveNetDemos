using Should.Fluent;
using SpecsAgainstGUI.Steps.PageObjects;
using TechTalk.SpecFlow;

namespace SpecsAgainstGUI.Steps
{
    [Binding]
    public class ActivityListPageSteps
    {
        public ActivityListPageSteps()
        {
            ScenarioContext.Current.Set(new ActivitiesPage());
        }

        private static ActivitiesPage Page { get { return ScenarioContext.Current.Get<ActivitiesPage>(); } }

        [Given(@"I am on the Activity list")]
        [When(@"I go to the Activity list")]
        public void GoToTheActivityList()
        {
            Page.Visit();
        }

        [When(@"I click the Create New link")]
        public void ClickNewLink()
        {
            Page.NavigateToCreateNew();
        }

        [Then(@"I should see a list of Activities for (.*)")]
        public void SeeActivitesForMyUser(string username)
        {
            Page.ActitvityTable_Who.Should().Not.Contain.Any(x => x != username);
        }

    }
}
