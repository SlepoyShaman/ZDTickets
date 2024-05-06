using Microsoft.EntityFrameworkCore;

namespace ZDTickets.Storage.Commands
{
    internal class RemoveOldTrainsAsync : BaseCommand
    {
        public override Task Execute(AppDbContext context)
            => context.Trains
            .Where(t => t.DepartureTime < DateTime.UtcNow)
            .ExecuteDeleteAsync();
    }
}
