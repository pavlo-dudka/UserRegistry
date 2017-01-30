using System.Linq;
using UserRegistry.Core.Models;

namespace UserRegistry.Core.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(UsersContext context = null) : base(context ?? new UsersContext())
        {
        }

        public int GetUsersCount(int id)
        {
            return DBContext.Set<User>().Count(u => u.CompanyId == id);
        }
    }
}
