using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using ActivityLog.Models.Storage;
using Ninject;
using Ninject.Mvc3;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ActivityLog.AppStart_NinjectMVC3), "Start")]

namespace ActivityLog {
    public static class AppStart_NinjectMVC3 {
        public static void RegisterServices(IKernel kernel) {
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IActivityRepository>().To<ActivityRepository>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<IPrincipal>().ToMethod(x => GetCurrentUser());
        }

        public static void Start() {
            // Create Ninject DI Kernel 
            IKernel kernel = new StandardKernel();

            // Register services with our Ninject DI Container
            RegisterServices(kernel);

            // Tell ASP.NET MVC 3 to use our Ninject DI Container 
            DependencyResolver.SetResolver(new NinjectServiceLocator(kernel));
        }

        public static IPrincipal GetCurrentUser()
        {
            return HttpContext.Current.User;
        }
    }
}
