namespace ZDTickets.Storage.Entities
{
    internal class TicketEntity
    {
        public long TicketId { get; set; }
        public int SeatNumber { get; set; }
        public int Price { get; set; }
        public long TrainId { get; set; }
        public string? UserId { get; set; }

        public TrainEntity Train { get; set; } = new();
        public User? User { get; set; }
    }

}
