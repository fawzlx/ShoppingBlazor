using System.Reflection;
using ShoppingBlazor.Infrastructure.Results;

namespace ShoppingBlazor.Services.Common;

public abstract class Paginator<T> : BasePagination
    where T : class
{
    protected virtual byte DefaultCount => 20;
    protected virtual byte MinCount => 1;
    protected virtual byte MaxCount => 100;

    public ResultList<T> Apply(IQueryable<T> models)
    {
        var count = models.Count();

        models = ApplyConditions(models);
        models = ApplyOrder(models);

        return new ResultList<T>(ApplyTakes(models), count);
    }

    protected abstract IQueryable<T> ApplyConditions(IQueryable<T> models);

    protected IOrderedQueryable<T> ApplyOrder(IQueryable<T> models)
    {
        var sortPropertyInfo = typeof(T).GetProperty(Sort ?? DefaultSortPropertyName);
        sortPropertyInfo ??= DefaultSortProperty() ?? typeof(T).GetProperties().First();

        return Order.Equals("Ascending", StringComparison.OrdinalIgnoreCase)
                ? models.OrderBy(x => sortPropertyInfo.GetValue(x))
                : models.OrderByDescending(x => sortPropertyInfo.GetValue(x));
    }

    protected PropertyInfo? DefaultSortProperty()
    {
        return typeof(T).GetProperty(DefaultSortPropertyName);
    }

    protected virtual string DefaultSortPropertyName => "Id";

    protected IList<T> ApplyTakes(IQueryable<T> models)
    {
        var index = Index > 0 ? Index : 0;
        var count = Take >= MinCount && Take <= MaxCount ? Take : DefaultCount;

        return models
            .Skip(count * index)
            .Take(count)
            .ToList();
    }
}