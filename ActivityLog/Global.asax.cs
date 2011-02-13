using System;
using System.Data.Entity.Database;
using System.Web.Mvc;
using System.Web.Routing;
using ActivityLog.Models;
using ActivityLog.Models.Storage;

namespace ActivityLog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Activities", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            DbDatabase.SetInitializer(new ActivityLogDbInitilaizer());
        }

        private class ActivityLogDbInitilaizer
        : DropCreateDatabaseIfModelChanges<ActivityLogContext>
        {
            protected override void Seed(ActivityLogContext context)
            {
                var fredric = new Person { PersonId = 2, Name = "Fredric Ståhlgren", Age = 40, Company = "Avega Elvate" };                
                var marcus = new Person { PersonId = 1, Name = "Administrator", Age = 37, Company = "Avega Enzo", Manager = fredric};
                var jocke = new Person { PersonId = 3, Name = "Joakim Sunden", Age = 35, Company = "Avega Modero", Manager = fredric};
                
                context.People.Add(fredric);
                context.People.Add(marcus);
                context.People.Add(jocke);

                var customer1 = new Customer { CustomerId = 1, Name = "LF", Contact = "Tobbe", Extra = "Intresserade av SpecFlow" };
                var customer2 = new Customer { CustomerId = 2, Name = "NK", Contact = "Hasse", Extra = "BDD, Kanban" };
                var customer3 = new Customer { CustomerId = 3, Name = "Progressive.NET", Contact = "Emil", Extra = "Intresserade av SpecFlow" };
                
                context.Customers.Add(customer1);
                context.Customers.Add(customer2);
                context.Customers.Add(customer3);

                var activity1 = new Activity {ActivityId = 1, AtCustomer = customer1, Who = marcus, Heading = "Kanban", NumberOfHours = 2, When = DateTime.Now.AddMonths(-2)};
                var activity2 = new Activity {ActivityId = 2, AtCustomer = customer1, Who = marcus, Heading = "BDD", NumberOfHours = 4, When = DateTime.Now.AddMonths(-3)};
                var activity3 = new Activity {ActivityId = 3, AtCustomer = customer2, Who = jocke, Heading = "Kanban", NumberOfHours = 4, When = DateTime.Now.AddMonths(-4)};
                var activity4 = new Activity {ActivityId = 4, AtCustomer = customer3, Who = marcus, Heading = "SpecFlow", NumberOfHours = 2, When = DateTime.Now.AddMonths(-5)};

                context.Activities.Add(activity1);
                context.Activities.Add(activity2);
                context.Activities.Add(activity3);
                context.Activities.Add(activity4);

                context.SaveChanges();
            }
        }
    }
}