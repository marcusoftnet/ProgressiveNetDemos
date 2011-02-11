using System.Data.Entity;

namespace ActivityLog.Models.Storage
{
    public class ActivityLogContext : DbContext
    {
        public DbSet<ActivityLog.Models.Activity> Activities { get; set; }
    
        public DbSet<ActivityLog.Models.Person> People { get; set; }
    
        public DbSet<ActivityLog.Models.Customer> Customers { get; set; }
    
        public ActivityLogContext()
        {
            // Instructions:
            //  * You can add custom code to this file. Changes will *not* be lost when you re-run the scaffolder.
            //  * If you want to regenerate the file totally, delete it and then re-run the scaffolder.
            //  * You can delete these comments if you wish
            //  * If you want Entity Framework to drop and regenerate your database automatically whenever you 
            //    change your model schema, uncomment the following line:
			//    DbDatabase.SetInitializer(new DropCreateDatabaseIfModelChanges<ActivityLogContext>());
        }
    }
}