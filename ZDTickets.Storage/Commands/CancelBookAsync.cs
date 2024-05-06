using Microsoft.EntityFrameworkCore;

namespace ZDTickets.Storage.Commands
{
    internal class CancelBookAsync : BaseCommand
    {
        private readonly string _userId;
        private readonly long[] _ticketsId;
        public CancelBookAsync(string userId, long[] ticketsId)
        {
            _userId = userId;
            _ticketsId = ticketsId;
        }
        public override async Task Execute(AppDbContext context)
        {
            var tickets = await context.Tickets
                .Where(t => _ticketsId.Contains(t.TicketId))
                .Where(t => t.UserId == _userId)
                .ToArrayAsync();

            if (tickets.Length != _ticketsId.Length)
            {
                var notFound = _ticketsId.Except(tickets.Select(t => t.TicketId));
                throw new InvalidOperationException($"Вы не бронировали билеты {string.Join(", ", notFound)}");
            }

            foreach (var ticket in tickets)
            {
                ticket.UserId = null;
                context.Update(ticket);
            }

            await context.SaveChangesAsync();
        }
    }
}
