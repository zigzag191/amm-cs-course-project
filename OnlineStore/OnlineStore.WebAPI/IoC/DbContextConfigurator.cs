using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess;
using OnlineStore.WebAPI.Settings;

namespace OnlineStore.WebAPI.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, OnlineStoreSettings settings)
    {
        services.AddDbContextFactory<OnlineStoreDbContext>(
            options => { options.UseSqlServer(settings.OnlineStoreDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<OnlineStoreDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
    }
}
