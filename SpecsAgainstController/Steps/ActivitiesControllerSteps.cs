using System.Collections.Generic;
using System.Web.Mvc;
using ActivityLog.Controllers;
using ActivityLog.Models;
using Should.Fluent;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecsAgainstController.Steps
{
    [Binding]
    public class ActivitiesControllerSteps
    {
        private static ActionResult LatestActionResult
        {
            get { return ScenarioContext.Current.Get<ActionResult>(); }
            set { ScenarioContext.Current.Set(value); }
        }


        [When(@"I go to the Activity list")]
        public void GoToActivityList()
        {
            var controller = new ActivitiesController(Substitutes.PersonRepository,
                                        Substitutes.CustomerRepository, 
                                        Substitutes.ActivtyRepository,
                                        Substitutes.Authentication);

            var actionResult = controller.Index();          // No assert in the Given & When steps, please
            LatestActionResult = actionResult;
        }


        [Then(@"I should see the following activites")]
        public  void IShouldSeeTheFollowingActivites(Table expectedActivites)
        {
            LatestActionResult.Should().Be.OfType(typeof(ViewResult));  // Asserts that you can read, please
            var viewResult = LatestActionResult as ViewResult;          // Asserts in the Then-step
        
            var activities = viewResult.Model as IEnumerable<Activity>;
            activities.Should().Not.Be.Null();

            expectedActivites.CompareToSet(activities);
        }
    }
}
