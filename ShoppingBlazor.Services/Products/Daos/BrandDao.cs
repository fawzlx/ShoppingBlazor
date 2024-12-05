using ShoppingBlazor.Databases.DbContexts;
using ShoppingBlazor.Databases.Repositories;
using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Services.Products.Daos;

public class BrandDao(IShoppingBlazorDbContext dbContext) : Repository<Brand>(dbContext)
{
    public override Brand Create(Brand entity)
    {
        var lastId = DbContext.Brands.Max(x => x.Id);

        entity.Id = lastId;

        DbContext.Brands = DbContext.Brands.Append(entity);

        return entity;
    }

    public override IQueryable<Brand> Read()
    {
        return DbContext.Brands.AsQueryable();
    }

    public override Brand? ReadById(long id)
    {
        return DbContext.Brands.SingleOrDefault(x => x.Id == (int)id);
    }

    public override Brand Update(Brand entity)
    {
        var oldBrand = DbContext.Brands.Single(x => x.Id == entity.Id);

        var brands = DbContext.Brands.ToList();

        var index = brands.IndexOf(entity);

        brands[index] = entity;

        DbContext.Brands = brands;

        return oldBrand;
    }

    public override Brand Delete(Brand entity)
    {
        var remainingBrands = DbContext.Brands.Where(x => x.Id != entity.Id);

        DbContext.Brands = remainingBrands;

        return entity;
    }

    public override Brand? DeleteById(long id)
    {
        var brand = DbContext.Brands.SingleOrDefault(x => x.Id == id);

        return brand is null ? null : Delete(brand);
    }
}