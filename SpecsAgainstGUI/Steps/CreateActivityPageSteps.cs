using Should.Fluent;
using SpecsAgainstGUI.Steps.PageObjects;
using TechTalk.SpecFlow;

namespace SpecsAgainstGUI.Steps
{
    [Binding]
    public class CreateActivityPageSteps
    {
        public CreateActivityPageSteps()
        {
            ScenarioContext.Current.Set(new CreateActivityPage());
        }

        private static CreateActivityPage Page { get { return ScenarioContext.Current.Get<CreateActivityPage>(); } }

        
        [Then(@"I should be on the Create Activity page")]
        public void BeOnCreateActivityPage()
        {
            Page.Title.Should().Equal("Create Activity");
        }
    }
}
