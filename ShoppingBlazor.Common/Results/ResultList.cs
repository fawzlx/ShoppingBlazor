namespace ShoppingBlazor.Infrastructure.Results;

public record ResultList<T>(IList<T> Results, int Total);