using Microsoft.EntityFrameworkCore;
using ZDTickets.Logic.Abstractions;
using ZDTickets.Logic.Models;
using ZDTickets.Logic.ViewModels;
using ZDTickets.Storage.Commands;
using ZDTickets.Storage.Requests;

namespace ZDTickets.Storage
{
    internal class AppStorage : IStorage
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        public AppStorage(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        public Task<TrainSummary[]> GetTrains(TrainsFilter trainsFilter)
            => Execute(new GetTrainsAsync(trainsFilter));
        public Task<Ticket[]> GetTicketsFromTrain(long trainId)
            => Execute(new GetTicketsFromTrainAsync(trainId));
        public Task<BookedTicket[]> GetBookedTickets(string userId)
            => Execute(new GetBookedTicketsAsync(userId));
        public Task CancelBook(string userId, long[] ticketsId)
            => Execute(new CancelBookAsync(userId, ticketsId));
        public Task RemoveOldTrains()
            => Execute(new RemoveOldTrainsAsync());
        public Task BookTrainTickets(string userId, long[] ticketsId)
            => Execute(new BookTrainTicketsAsync(userId, ticketsId));

        private async Task Execute(BaseCommand command)
        {
            using var context = _factory.CreateDbContext();
            await command.Execute(context);
        }

        private async Task<T> Execute<T>(BaseRequest<T> request)
        {
            using var context = _factory.CreateDbContext();
            return await request.Execute(context);
        }
    }
}
