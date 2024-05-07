using Microsoft.AspNetCore.Mvc;
using ZDTickets.Logic.Identity;
using ZDTickets.Logic.ViewModels;

namespace ZDTickets.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task Register([FromBody] RegisterViewModel model)
        {
            await _userService.Register(model);
            SetExpiresHeader();
        }

        [HttpPost("login")]
        public async Task Login([FromBody] LoginViewModel model)
        {
            await _userService.Login(model);
            SetExpiresHeader();
        }

        [HttpPost("logout")]
        public void Logout() => _userService.Logout();

        private void SetExpiresHeader()
        {
            var date = DateTime.Now + TimeSpan.FromDays(1);
            HttpContext.Response.Headers.Expires = date.ToString();
        }
    }
}
