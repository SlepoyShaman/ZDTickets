using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ZDTickets.Storage
{
    internal class DbContextDesign : IDesignTimeDbContextFactory<AppDbContext>
    {
        AppDbContext IDesignTimeDbContextFactory<AppDbContext>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseNpgsql(Environment.GetEnvironmentVariable("DbMigrationConnectionString"));
            return new AppDbContext(builder.Options);
        }
    }
}
