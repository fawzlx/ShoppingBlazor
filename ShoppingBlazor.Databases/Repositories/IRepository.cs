using ShoppingBlazor.Entities.Common;

namespace ShoppingBlazor.Databases.Repositories;

public interface IRepository<T>
    where T : IEntity
{
    T Create(T entity);
    IQueryable<T> Read();
    T? ReadById(long id);
    T Update(T entity);
    T Delete(T entity);
    T? DeleteById(long id);
}