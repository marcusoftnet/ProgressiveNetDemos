using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActivityLog.Models;
using ActivityLog.Models.Storage;

namespace ActivityLog.Controllers
{   
    public class PeopleController : Controller
    {
		private readonly IPersonRepository personRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PeopleController() : this(new PersonRepository())
        {
        }

        public PeopleController(IPersonRepository personRepository)
        {
			this.personRepository = personRepository;
        }

        //
        // GET: /Person/

        public ViewResult Index()
        {
            return View(personRepository.GetAllPeople(person => person.Manager));
        }

        //
        // GET: /Person/Details/5

        public ViewResult Details(int id)
        {
            return View(personRepository.GetById(id));
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
			ViewBag.PossibleManagers = personRepository.GetAllPeople();
            return View();
        } 

        //
        // POST: /Person/Create

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid) {
                personRepository.InsertOrUpdate(person);
                personRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleManagers = personRepository.GetAllPeople();
				return View();
			}
        }
        
        //
        // GET: /Person/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleManagers = personRepository.GetAllPeople();
             return View(personRepository.GetById(id));
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid) {
                personRepository.InsertOrUpdate(person);
                personRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleManagers = personRepository.GetAllPeople();
				return View();
			}
        }

        //
        // GET: /Person/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(personRepository.GetById(id));
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            personRepository.Delete(id);
            personRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

