using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZDTickets.Logic.Identity;
using ZDTickets.Logic.Tickets;

namespace ZDTickets.Logic
{
    public static class ServiceProvider
    {
        public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITicketService, TicketService>();
            return services;
        }
    }
}
