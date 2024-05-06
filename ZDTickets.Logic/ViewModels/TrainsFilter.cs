using Microsoft.AspNetCore.Mvc;

namespace ZDTickets.Logic.ViewModels
{
    public class TrainsFilter
    {
        [FromQuery(Name = "page")]
        public int PageNumber { get; set; }
        [FromQuery(Name = "size")]
        public int PageSize { get; set; }
        [FromQuery(Name = "from")]
        public string? FromCity { get; set; }
        [FromQuery(Name = "to")]
        public string? ToCity { get; set; }
        [FromQuery(Name = "date")]
        public DateTime? Date { get; set; }
    }
}
