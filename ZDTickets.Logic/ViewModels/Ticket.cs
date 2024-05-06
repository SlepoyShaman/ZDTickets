namespace ZDTickets.Logic.Models
{
    public class BaseTicket
    {
        public long TicketId { get; set; }
        public int SeatNumber { get; set; }
        public int Price { get; set; }
    }
    public class Ticket : BaseTicket
    {
        public bool Reserved { get; set; }
    }

    public class BookedTicket : BaseTicket
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
