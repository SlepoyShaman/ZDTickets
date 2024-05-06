using Microsoft.EntityFrameworkCore;
using ZDTickets.Logic.Models;

namespace ZDTickets.Storage.Requests
{
    internal class GetTicketsFromTrainAsync : BaseRequest<Ticket[]>
    {
        private readonly long _trainId;
        public GetTicketsFromTrainAsync(long trainId)
        {
            _trainId = trainId;
        }
        public override async Task<Ticket[]> Execute(AppDbContext context)
        {
            var train = await context.Trains
                .Include(t => t.Tickets)
                .FirstOrDefaultAsync(t => t.TrainId == _trainId)
                ?? throw new KeyNotFoundException($"Не найден поезд с id: {_trainId}");

            if (train.DepartureTime < DateTime.UtcNow)
            {
                context.Trains.Remove(train);
                throw new InvalidOperationException($"Поезд {_trainId} уже уехал");
            }

            return train.Tickets
                .Select(t => new Ticket()
                {
                    TicketId = t.TicketId,
                    Price = t.Price,
                    SeatNumber = t.SeatNumber,
                    Reserved = t.UserId is not null
                })
                .ToArray();
        }
    }
}
