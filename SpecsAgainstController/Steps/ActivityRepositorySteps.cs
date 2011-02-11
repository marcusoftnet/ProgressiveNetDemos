using System.Collections.Generic;
using System.Linq;
using ActivityLog.Models;
using ActivityLog.Models.Storage;
using NSubstitute;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecsAgainstController.Steps
{
    [Binding]
    public class ActivityRepositorySteps
    {
        [Given(@"the following activities in the database")]
        public void SetupActivities(Table activitiesTable)
        {
            var activities = activitiesTable.CreateSet<Activity>().ToList();

            #region Need to create the complex object - but it sure was beatiful so far, right?

            for (var i = 0; i < activities.Count(); i++)
            {
                var activityRow = RowForActivityId(activities[i].ActivityId, activitiesTable);
                activities[i].AtCustomer = CustomerForActivityIDInTable(activityRow);
                activities[i].Who = PersonForActivityIDInTable(activityRow);
            }
            #endregion

            Substitutes.ActivtyRepository.GetAllActivities().Returns(activities);

        }

        private static TableRow RowForActivityId(int activityIdOnRow, Table activitiesTable)
        {
            return activitiesTable.Rows.Single(x => x["Activity id"] == activityIdOnRow.ToString());
        }

        private static Customer CustomerForActivityIDInTable(TableRow row)
        {
            return new Customer {Name = row["At Customer"]};
        }

        private static Person PersonForActivityIDInTable(TableRow row)
        {
            return new Person { Name = row["Who"]};
        }

    }
}
