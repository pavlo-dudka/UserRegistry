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

        public UsersContext() : base("name=Database")
        {
            //Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<UsersContext>(new DbInitializer());
        }

        public System.Data.Entity.DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var ec = new EntityTypeConfiguration<User>().
            //modelBuilder.Entity<User>().HasRequired(u => u.Company).WithMany(c => c.Users).HasForeignKey(u => u.CompanyId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
