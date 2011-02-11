using System.Security.Principal;
using ActivityLog.Models.Storage;
using NSubstitute;
using TechTalk.SpecFlow;

namespace SpecsAgainstController.Steps
{
    public static class Substitutes
    {
        private const string ACTIVITY_KEY = "ActivityRepositoryKey";
        private const string CUSTOMER_KEY = "CustomerRepositoryKey";
        private const string PERSON_KEY = "PersonRepositoryKey";
        private const string AUTH_KEY = "AuthenticationKey";
       
        public static IActivityRepository ActivtyRepository
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(ACTIVITY_KEY))
                {
                    var mockedRepository = Substitute.For<IActivityRepository>();
                    ScenarioContext.Current.Set(mockedRepository, ACTIVITY_KEY);
                }
                return ScenarioContext.Current.Get<IActivityRepository>(ACTIVITY_KEY);
            }
        }

        public static ICustomerRepository CustomerRepository
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(CUSTOMER_KEY))
                {
                    var mockedRepository = Substitute.For<ICustomerRepository>();
                    ScenarioContext.Current.Set(mockedRepository, CUSTOMER_KEY);
                }
                return ScenarioContext.Current.Get<ICustomerRepository>(CUSTOMER_KEY);
            }
        }

        public static IPersonRepository PersonRepository
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(PERSON_KEY))
                {
                    var mockedRepository = Substitute.For<IPersonRepository>();
                    ScenarioContext.Current.Set(mockedRepository, PERSON_KEY);
                }
                return ScenarioContext.Current.Get<IPersonRepository>(PERSON_KEY);
            }
        }

        public static IPrincipal Authentication
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(AUTH_KEY))
                {
                    var mockedRepository = Substitute.For<IPrincipal>();
                    ScenarioContext.Current.Set(mockedRepository, AUTH_KEY);
                }
                return ScenarioContext.Current.Get<IPrincipal>(AUTH_KEY);
            }
        }
    }
}
