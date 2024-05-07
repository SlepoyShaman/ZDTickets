using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZDTickets.Logic.Models;
using ZDTickets.Logic.Tickets;
using ZDTickets.Logic.ViewModels;

namespace ZDTickets.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _tickets;
        public TicketsController(ITicketService tickets)
        {
            _tickets = tickets;
        }

        [HttpGet("trains")]
        public Task<TrainSummary[]> GetTrains([FromQuery] TrainsFilter filter)
            => _tickets.GetAllTrains(filter);
        [HttpGet("train/{trainId}")]
        public Task<Ticket[]> GetTicketsFromTrain([FromRoute] long trainId)
            => _tickets.GetTicketsFromTrain(trainId);
        [HttpGet("booked")]
        public Task<BookedTicket[]> GetBookedTickets()
            => _tickets.GetBookedTickets(UserName);
        [HttpPost("book")]
        public Task BookTickets([FromBody] long[] ticketsId)
            => _tickets.BookTrainTickets(UserName, ticketsId);
        [HttpPost("cancel")]
        public Task CancelBook([FromBody] long[] ticketsId)
            => _tickets.CancelBook(UserName, ticketsId);
        private string UserName => User.Identity?.Name
                ?? throw new Exception("Не удалось получить имя пользователя, попробуйте снова");
    }
}
