using ShoppingBlazor.Databases.DbContexts;
using ShoppingBlazor.Databases.Repositories;
using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Services.Products.Daos;

public class StuffDao(IShoppingBlazorDbContext dbContext) : Repository<Stuff>(dbContext)
{
    public override Stuff Create(Stuff entity)
    {
        var nextId = DbContext.Stuffs.MaxBy(x => x.Id)?.Id + 1 ?? 1;

        entity.Id = nextId;

        DbContext.Stuffs = DbContext.Stuffs.Append(entity);

        return entity;
    }

    public override IQueryable<Stuff> Read()
    {
        return DbContext.Stuffs.AsQueryable();
    }

    public override Stuff? ReadById(long id)
    {
        return DbContext.Stuffs.SingleOrDefault(x => x.Id == (int)id);
    }

    public override Stuff Update(Stuff entity)
    {
        var oldStuff = DbContext.Stuffs.Single(x => x.Id == entity.Id);

        var stuffs = DbContext.Stuffs.ToList();

        var index = stuffs.IndexOf(oldStuff);

        stuffs[index] = entity;

        DbContext.Stuffs = stuffs;

        return oldStuff;
    }

    public override Stuff Delete(Stuff entity)
    {
        var remainingStuffs = DbContext.Stuffs.Where(x => x.Id != entity.Id);

        DbContext.Stuffs = remainingStuffs;

        return entity;
    }

    public override Stuff? DeleteById(long id)
    {
        var stuff = DbContext.Stuffs.SingleOrDefault(x => x.Id == id);

        return stuff is null ? null : Delete(stuff);
    }
}