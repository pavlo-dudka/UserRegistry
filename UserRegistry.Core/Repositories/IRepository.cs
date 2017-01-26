using System.Linq;

namespace UserRegistry.Core.Repositories
{
  public interface IRepository<T>
  {
    IQueryable<T> GetAll();
    T GetSingle(int Id);
    void Add(T entity);
    void Delete(T entity);
    void Edit(T entity);
    bool Save();
  }
}
