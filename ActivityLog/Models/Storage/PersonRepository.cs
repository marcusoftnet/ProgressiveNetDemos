using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ActivityLog.Models.Storage
{ 
    public class PersonRepository : IPersonRepository
    {
        ActivityLogContext context = new ActivityLogContext();

        public IEnumerable<Person> GetAllPeople(params Expression<Func<Person, object>>[] includeProperties)
        {
            IQueryable<Person> query = context.People;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public Person GetById(int id)
        {
            return context.People.Find(id);
        }

        public void InsertOrUpdate(Person person)
        {
            if (person.PersonId == 0) {
                // New entity
                context.People.Add(person);
            } else {
                // Existing entity
                context.People.Attach(person);
                context.Entry(person).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var person = context.People.Find(id);
            context.People.Remove(person);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}