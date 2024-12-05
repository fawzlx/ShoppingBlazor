using System.Reflection;

namespace ShoppingBlazor.Services.Common;

public abstract class Paginator<T> where T : class
{
    public int? Index { get; set; }
    public int? Take { get; set; }
    public string? Order { get; set; }
    public string? Sort { get; set; }

    protected virtual byte DefaultCount => 20;
    protected virtual byte MinCount => 1;
    protected virtual byte MaxCount => 100;

    public (IList<T> Result, int TotalCount) Apply(IQueryable<T> models)
    {
        var count = models.Count();

        models = ApplyConditions(models);
        models = ApplyOrder(models);

        return (ApplyTakes(models), count);
    }

    protected abstract IQueryable<T> ApplyConditions(IQueryable<T> models);

    protected IOrderedQueryable<T> ApplyOrder(IQueryable<T> models)
    {
        var sortPropertyInfo = typeof(T).GetProperty(Sort ?? string.Empty);
        sortPropertyInfo ??= DefaultSortProperty() ?? typeof(T).GetProperties().First();

        return Order is not null && Order.Equals("asc", StringComparison.OrdinalIgnoreCase)
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
        var index = Index is > 0 ? Index.Value : 0;
        var count = Take >= MinCount && Take <= MaxCount ? Take.Value : DefaultCount;

        return models
            .Skip(count * index)
            .Take(count)
            .ToList();
    }
}