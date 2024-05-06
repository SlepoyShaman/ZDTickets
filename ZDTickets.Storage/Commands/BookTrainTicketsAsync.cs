using Microsoft.EntityFrameworkCore;

namespace ZDTickets.Storage.Commands
{
    internal class BookTrainTicketsAsync : BaseCommand
    {
        private readonly string _userId;
        private readonly long[] _ticketsId;
        public BookTrainTicketsAsync(string userId, long[] ticketsId)
        {
            _userId = userId;
            _ticketsId = ticketsId;
        }
        public override async Task Execute(AppDbContext context)
        {
            var tickets = await context.Tickets
                .Where(t => _ticketsId.Contains(t.TicketId))
                .ToArrayAsync();

            if (tickets.Length != _ticketsId.Length)
            {
                var notFound = _ticketsId.Except(tickets.Select(t => t.TicketId));
                throw new KeyNotFoundException($"билеты {string.Join(", ", notFound)} не найдены");
            }

            var taken = tickets
                .Where(t => t.UserId is not null)
                .Select(t => t.TicketId);
            if (taken.Any())
                throw new InvalidOperationException($"билеты {string.Join(", ", taken)} уже забронированы");

            foreach (var ticket in tickets)
            {
                ticket.UserId = _userId;
                context.Update(ticket);
            }

            await context.SaveChangesAsync();
        }
    }
}
