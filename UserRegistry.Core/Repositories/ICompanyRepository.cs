using System;
using UserRegistry.Core.Models;

namespace UserRegistry.Core.Repositories
{
  public interface ICompanyRepository : IRepository<Company>, IDisposable
  {
    int GetUsersCount(int id);
  }
}
