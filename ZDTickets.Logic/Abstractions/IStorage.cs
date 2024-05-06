using ZDTickets.Logic.Models;
using ZDTickets.Logic.ViewModels;

namespace ZDTickets.Logic.Abstractions
{
    public interface IStorage
    {
        public Task<TrainSummary[]> GetTrains(TrainsFilter trainsFilter);
        public Task<Ticket[]> GetTicketsFromTrain(long trainId);
        public Task<BookedTicket[]> GetBookedTickets(string userId);
        public Task CancelBook(string userId, long[] ticketsId);
        public Task RemoveOldTrains();
        public Task BookTrainTickets(string userId, long[] ticketsId);
    }
}
