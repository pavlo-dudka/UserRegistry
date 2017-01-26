using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using UserRegistry.Core.Models;

namespace UserRegistry.Core.Migrations
{
    class DbInitializer : CreateDatabaseIfNotExists<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            context.Users.AddRange(new User[] {
                new User() { Name = "User 1", CompanyId = 1},
                new User() { Name = "User 2", CompanyId = 1},
                new User() { Name = "User 3", CompanyId = 2},
            });

            context.Companies.AddRange(new Company[] {
                new Company() { Name = "Company 1"},
                new Company() { Name = "Company 2"},
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
