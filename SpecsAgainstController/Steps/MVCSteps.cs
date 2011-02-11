using NSubstitute;
using TechTalk.SpecFlow;

namespace SpecsAgainstController.Steps
{
    [Binding]
    public class MVCSteps
    {
        [Given(@"I am logged in as (.*)")]
        public void LoggedInAs(string user)
        {
            Substitutes.Authentication.Identity.IsAuthenticated.Returns(true);
            Substitutes.Authentication.Identity.Name.Returns(user);
        }
    }
}
