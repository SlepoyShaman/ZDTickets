using Microsoft.AspNetCore.Identity;

namespace ZDTickets.Storage.Entities
{
    internal class User : IdentityUser
    {
        public List<TicketEntity> Tickets { get; set; } = [];
    }
}
