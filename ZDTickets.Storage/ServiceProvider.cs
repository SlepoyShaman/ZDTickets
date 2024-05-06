using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZDTickets.Logic.Abstractions;
using ZDTickets.Storage.Entities;
using ZDTickets.Storage.Identity;

namespace ZDTickets.Storage
{
    public static class ServiceProvider
    {
        private const string _connectionStringName = "PostgreSQL";
        public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IStorage, AppStorage>();
            services.AddScoped<IUserStorage, UserStorage>();
            services.AddDbContextFactory<AppDbContext>(options =>
            {
                var connString = configuration.GetConnectionString(_connectionStringName)
                    ?? throw new Exception("Отсутсвует строка подключения");
                options.UseNpgsql(connString);
            });
            services.AddIdentity<User, IdentityRole>(a =>
            {
                a.Password = new()
                {
                    RequireNonAlphanumeric = false,
                    RequireDigit = false,
                    RequiredLength = 5,
                    RequiredUniqueChars = 0,
                    RequireLowercase = false,
                    RequireUppercase = false
                };
            })
                .AddEntityFrameworkStores<AppDbContext>();
            return services;
        }
    }
}
