using ZDTickets.Logic.Models;
using ZDTickets.Logic.ViewModels;

namespace ZDTickets.Logic.Tickets
{
    public interface ITicketService
    {
        public Task<TrainSummary[]> GetAllTrains(TrainsFilter filter);
        public Task<Ticket[]> GetTicketsFromTrain(long trainId);
        public Task<BookedTicket[]> GetBookedTickets(string userName);
        public Task BookTrainTickets(string userName, long[] ticketsId);
        public Task CancelBook(string userId, long[] ticketsId);
    }
}
