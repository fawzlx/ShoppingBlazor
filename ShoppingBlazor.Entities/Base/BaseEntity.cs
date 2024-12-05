namespace ShoppingBlazor.Entities.Base;

public class BaseEntity<TId> : IEntity
    where TId : struct
{
    public required TId Id { get; set; }
}