using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ActivityLog.Models.Storage
{ 
    public class ActivityRepository : IActivityRepository
    {
        ActivityLogContext context = new ActivityLogContext();

        public IEnumerable<Activity> GetAllActivities(params Expression<Func<Activity, object>>[] includeProperties)
        {
            IQueryable<Activity> query = context.Activities;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Activity GetById(int id)
        {
            return context.Activities.Find(id);
        }

        public void InsertOrUpdate(Activity activity)
        {
            if (activity.ActivityId == 0) {
                // New entity
                context.Activities.Add(activity);
            } else {
                // Existing entity
                context.Activities.Attach(activity);
                context.Entry(activity).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var activity = context.Activities.Find(id);
            context.Activities.Remove(activity);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}