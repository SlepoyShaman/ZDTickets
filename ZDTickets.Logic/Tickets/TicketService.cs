using ZDTickets.Logic.Abstractions;
using ZDTickets.Logic.Models;
using ZDTickets.Logic.ViewModels;

namespace ZDTickets.Logic.Tickets
{
    internal class TicketService : ITicketService
    {
        private readonly IStorage _storage;
        private readonly IUserStorage _userStorage;
        public TicketService(IStorage storage, IUserStorage userStorage)
        {
            _storage = storage;
            _userStorage = userStorage;
        }

        public async Task<TrainSummary[]> GetAllTrains(TrainsFilter filter)
        {
            await _storage.RemoveOldTrains();
            return await _storage.GetTrains(filter);
        }

        public Task<Ticket[]> GetTicketsFromTrain(long trainId)
            => _storage.GetTicketsFromTrain(trainId);

        public async Task<BookedTicket[]> GetBookedTickets(string userName)
        {
            var userid = await _userStorage.GetIdByUserName(userName);
            return await _storage.GetBookedTickets(userid);
        }

        public async Task BookTrainTickets(string userName, long[] ticketsId)
        {
            var userId = await _userStorage.GetIdByUserName(userName);
            await _storage.BookTrainTickets(userId, ticketsId);
        }

        public async Task CancelBook(string userName, long[] ticketsId)
        {
            var userId = await _userStorage.GetIdByUserName(userName);
            await _storage.CancelBook(userId, ticketsId);
        }
    }
}
