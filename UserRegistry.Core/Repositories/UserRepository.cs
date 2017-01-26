using UserRegistry.Core.Models;

namespace UserRegistry.Core.Repositories
{
  public class UserRepository : Repository<User>, IUserRepository
  {
    public UserRepository() : base(new UsersContext())
    {
    }
  }
}
