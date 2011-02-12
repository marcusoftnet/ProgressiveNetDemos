using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ActivityLog.Controllers;
using ActivityLog.Models;
using Should.Fluent;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NSubstitute;
using SpecsAgainstController.Helpers;

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

        private static ActivitiesController CreateActivityController()
        {
            return new ActivitiesController(Substitutes.PersonRepository, Substitutes.CustomerRepository,
                                            Substitutes.ActivtyRepository, Substitutes.Authentication);
        }

        [When(@"I go to the Activity list")]
        [When(@"I am redirected to the Activity list")]
        public void GoToActivityList()
        {
            var controller = CreateActivityController();

            var actionResult = controller.Index();          // No assert in the Given & When steps, please
            LatestActionResult = actionResult;
        }

        [Then(@"I should see the following activites")]
        public void IShouldSeeTheFollowingActivites(Table expectedActivites)
        {
            LatestActionResult.Should().Be.OfType(typeof(ViewResult));  // Asserts that you can read, please
            var viewResult = LatestActionResult as ViewResult;          // Asserts in the Then-step

            var activities = viewResult.Model as IEnumerable<Activity>;
            activities.Should().Not.Be.Null();

            expectedActivites.CompareToSet(activities);
        }






        [When(@"I navigate to to the Add Activity page")]
        public void WhenINavigateToToTheAddActivityPage()
        {
            ActivitiesController controller = CreateActivityController();
            LatestActionResult = controller.Create();
        }

        [When(@"I submit an activitiy with this information")]
        public void WhenISubmitAnActivitiyWithThisInformation(Table activityInfo)
        {
            var submittedActivity = activityInfo.CreateInstance<Activity>();

            // Use (my) extension method to get a "customer" with name
            submittedActivity.AtCustomer = new Customer { Name = activityInfo.GetValueForField("At Customer") };
            submittedActivity.Who = new Person { Name = activityInfo.GetValueForField("Who") };

            var controller = CreateActivityController();
            LatestActionResult = controller.Create(submittedActivity);

            // Update the list we're expecting back with next call to GetAllActivities()
            // with the submitted activity
            var newActivityList = ActivityRepositorySteps.InitialActivities;
            newActivityList.Add(submittedActivity);
            Substitutes.ActivtyRepository.GetAllActivities().Returns(newActivityList);
        }

        [Then(@"I should be redirected the Activity list")]
        public void ThenIShouldBeRedirectedTheActivityList()
        {
            LatestActionResult.Should().Be.OfType(typeof(RedirectToRouteResult));

            var redirectResult = LatestActionResult as RedirectToRouteResult;
            redirectResult.RouteValues["action"].Should().Equal("Index");
        }
    }
}
