namespace ShoppingBlazor.Entities.Common;

public class BaseEntity<TId> : IEntity
    where TId : struct
{
    public required TId Id { get; set; }
}