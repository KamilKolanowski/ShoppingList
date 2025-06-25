using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Data;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;
using ShoppingListAPI.Services;

namespace ShoppingListAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ShoppingListDbContext>(opt =>
            opt.UseSqlServer(connectionString)
        );
        // Add repositories
        builder.Services.AddScoped<IDataRepository<ShoppingList>, ShoppingListRepository>();
        builder.Services.AddScoped<IDataRepository<ShoppingListItem>, ShoppingListItemRepository>();
        builder.Services.AddScoped<IDataRepository<Product>, ProductRepository>();

        // Add services for API
        builder.Services.AddScoped<IEntityService<ShoppingList>, ShoppingListService>();
        builder.Services.AddScoped<IEntityService<ShoppingListItem>, ShoppingListItemService>();
        builder.Services.AddScoped<IEntityService<Product>, ProductService>();
        builder.Services.AddControllers();
        
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
            });
        });

        var app = builder.Build();

        app.UseRouting();
        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
