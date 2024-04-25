using System.Linq.Expressions;

namespace Plancraft.Domain.Repository.Abstraction;

public interface IRepository<T>
{
    T GetById(object id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    T Add(T entity);
    T Update(T entity);
    void Remove(T entity);
}