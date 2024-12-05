using ShoppingBlazor.Databases.DbContexts;
using ShoppingBlazor.Entities.Common;
using ShoppingBlazor.Infrastructure.DI;

namespace ShoppingBlazor.Databases.Repositories;

public abstract class Repository<T>(IShoppingBlazorDbContext dbContext) : IRepository<T>, IScopedService
    where T : IEntity
{
    protected readonly IShoppingBlazorDbContext DbContext = dbContext;

    public abstract T Create(T entity);

    public abstract IQueryable<T> Read();

    public abstract T? ReadById(long id);

    public abstract T Update(T entity);

    public abstract T Delete(T entity);

    public abstract T? DeleteById(long id);
}