namespace ZDTickets.Storage.Entities
{
    internal class TrainEntity
    {
        public long TrainId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public List<TicketEntity> Tickets { get; set; } = [];
    }
}
