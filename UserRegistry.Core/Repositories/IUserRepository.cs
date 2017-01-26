using System;
using UserRegistry.Core.Models;

namespace UserRegistry.Core.Repositories
{
  public interface IUserRepository : IRepository<User>, IDisposable
  {
  }
}
