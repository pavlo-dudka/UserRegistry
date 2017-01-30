using UserRegistry.Core.Models;

namespace UserRegistry.Core.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UsersContext context = null) : base(context ?? new UsersContext())
        {
        }
    }
}
