using MudBlazor.Services;
using ShoppingBlazor.Components;
using ShoppingBlazor.Databases.DbContexts;
using ShoppingBlazor.Databases.Repositories;
using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Services.Products;
using ShoppingBlazor.Services.Products.Daos;
using ShoppingBlazor.States;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();

// Confirm services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// builder.Services.Scan(x => x
//         .FromAssemblies(
//             AssemblyExtension.GetProjectAssemblies()
//         )
//         .AddClasses(classes => classes.Where(y => y.GetInterfaces().Contains(typeof(ISingletonService))))
//         .AsMatchingInterface()
//         .WithSingletonLifetime()
//     .AddClasses(classes => classes.Where(y => y.GetInterfaces().Contains(typeof(ITransientService))))
//     .AsImplementedInterfaces()
//     .WithTransientLifetime()
//      .AddClasses(classes => classes.Where(y => y.GetInterfaces().Contains(typeof(IScopedService))))
//      .AsMatchingInterface()
//     .WithScopedLifetime()
//     );

builder.Services.AddSingleton<IShoppingBlazorDbContext, ShoppingBlazorDbContext>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddTransient<IRepository<Stuff>, StuffDao>();
builder.Services.AddTransient<IRepository<Brand>, BrandDao>();
builder.Services.AddTransient<IRepository<Category>, CategoryDao>();
builder.Services.AddScoped<AddStuffState>();
builder.Services.AddScoped<RemoveStuffState>();
builder.Services.AddScoped<EditStuffState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();