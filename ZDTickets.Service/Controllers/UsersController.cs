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
        public Task Register([FromBody] RegisterViewModel model)
            => _userService.Register(model);
        [HttpPost("login")]
        public Task Login([FromBody] LoginViewModel model)
            => _userService.Login(model);
        [HttpPost("logout")]
        public Task Logout() => _userService.Logout();
    }
}
