using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Moq;
using UserRegistry.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserRegistry.Core.Repositories.Tests
{
    [TestClass()]
    public class CompanyRepositoryTests
    {
        private static Mock<DbSet<T>> MockedDbSet<T>(IQueryable<T> list) where T : class
        {
            var moqDbSet = new Mock<DbSet<T>>();
            moqDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(list.Provider);
            moqDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(list.Expression);
            moqDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(list.ElementType);
            moqDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            return moqDbSet;
        }

        private static Mock<UsersContext> MockedDbContext()
        {
            var moqDbContext = new Mock<UsersContext>();

            var userList = new List<User>{
                new User() { CompanyId = 1, Name = "user 1" },
                new User() { CompanyId = 2, Name = "user 2" },
                new User() { CompanyId = 2, Name = "user 3" }
            }.AsQueryable();
            var moqUserSet = MockedDbSet(userList);
            moqDbContext.Setup(m => m.Users).Returns(moqUserSet.Object);
            moqDbContext.Setup(m => m.Set<User>()).Returns(moqUserSet.Object);

            var companyList = new List<Company>{
                new Company() { Id = 1, Name = "company 1" },
                new Company() { Id = 2, Name = "company 2" }
            }.AsQueryable();
            var moqCompanySet = MockedDbSet(companyList);
            moqDbContext.Setup(m => m.Companies).Returns(moqCompanySet.Object);
            moqDbContext.Setup(m => m.Set<Company>()).Returns(moqCompanySet.Object);

            return moqDbContext;
        }

        [TestMethod()]
        public void GetUsersCountTest()
        {
            Mock<UsersContext> moqDbContext = MockedDbContext();

            var companyRep = new CompanyRepository(moqDbContext.Object);
            Assert.AreEqual(2, companyRep.GetUsersCount(2));
        }
    }
}