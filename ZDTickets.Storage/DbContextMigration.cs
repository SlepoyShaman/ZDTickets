using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZDTickets.Storage
{
    public static class DbContextMigration
    {
        public static IServiceProvider MigrateDatabase(this IServiceProvider service)
        {
            using var scope = service.CreateScope();
            var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
            using var dbContext = dbContextFactory.CreateDbContext();
            dbContext.Database.Migrate();
            return service;
        }
    }
}
