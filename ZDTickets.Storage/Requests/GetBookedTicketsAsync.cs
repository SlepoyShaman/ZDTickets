using Microsoft.EntityFrameworkCore;
using ZDTickets.Logic.Models;

namespace ZDTickets.Storage.Requests
{
    internal class GetBookedTicketsAsync : BaseRequest<BookedTicket[]>
    {
        private readonly string _userId;
        public GetBookedTicketsAsync(string userId)
        {
            _userId = userId;
        }
        public override Task<BookedTicket[]> Execute(AppDbContext context)
            => context.Tickets
            .Where(t => t.UserId == _userId)
            .Select(t => new BookedTicket()
            {
                TicketId = t.TicketId,
                Price = t.Price,
                SeatNumber = t.SeatNumber,
                From = t.Train.From,
                To = t.Train.To,
                DepartureTime = t.Train.DepartureTime,
                ArrivalTime = t.Train.ArrivalTime
            })
            .ToArrayAsync();

    }
}
