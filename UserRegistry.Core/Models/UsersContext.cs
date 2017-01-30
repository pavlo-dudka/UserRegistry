using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using UserRegistry.Core.Migrations;

namespace UserRegistry.Core.Models
{
    public class UsersContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        static UsersContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public UsersContext() : base("name=Database")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Company> Companies { get; set; }
    }
}
