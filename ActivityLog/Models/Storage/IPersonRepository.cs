using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ActivityLog.Models.Storage
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople(params Expression<Func<Person, object>>[] includeProperties);
        Person GetById(int id);
        void InsertOrUpdate(Person person);
        void Delete(int id);
        void Save();
    }
}