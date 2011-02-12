using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using ActivityLog.Models;
using ActivityLog.Models.Storage;

namespace ActivityLog.Controllers
{   
    public class ActivitiesController : Controller
    {
		private readonly IPersonRepository personRepository;
		private readonly ICustomerRepository customerRepository;
		private readonly IActivityRepository activityRepository;
        private readonly IPrincipal authentication;
        
        public ActivitiesController(IPersonRepository personRepository, ICustomerRepository customerRepository, 
            IActivityRepository activityRepository, IPrincipal authentication)
        {
			this.personRepository = personRepository;
			this.customerRepository = customerRepository;
			this.activityRepository = activityRepository;
            this.authentication = authentication;
        }

        //
        // GET: /Activity/

        public ViewResult Index()
        {
            var activities = activityRepository.GetAllActivities();

            if (authentication.Identity.IsAuthenticated)
            {
                activities = from a in activities
                             where a.Who.Name == authentication.Identity.Name
                             select a;
            }
            
            return View("Index",activities);
        }

        //
        // GET: /Activity/Details/5

        public ViewResult Details(int id)
        {
            return View(activityRepository.GetById(id));
        }

        //
        // GET: /Activity/Create

        public ActionResult Create()
        {
			ViewBag.PossiblePeople = personRepository.GetAllPeople();
			ViewBag.PossibleCustomers = customerRepository.GetAllCustomers();
            return View();
        } 

        //
        // POST: /Activity/Create

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid) {
                activityRepository.InsertOrUpdate(activity);
                activityRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossiblePeople = personRepository.GetAllPeople();
				ViewBag.PossibleCustomers = customerRepository.GetAllCustomers();
				return View();
			}
        }
        
        //
        // GET: /Activity/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossiblePeople = personRepository.GetAllPeople();
			ViewBag.PossibleCustomers = customerRepository.GetAllCustomers();
             return View(activityRepository.GetById(id));
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid) {
                activityRepository.InsertOrUpdate(activity);
                activityRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossiblePeople = personRepository.GetAllPeople();
				ViewBag.PossibleCustomers = customerRepository.GetAllCustomers();
				return View();
			}
        }

        //
        // GET: /Activity/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(activityRepository.GetById(id));
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            activityRepository.Delete(id);
            activityRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

