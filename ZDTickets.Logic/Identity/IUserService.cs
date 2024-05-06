using ZDTickets.Logic.ViewModels;

namespace ZDTickets.Logic.Identity
{
    public interface IUserService
    {
        public Task Register(RegisterViewModel model);
        public Task Login(LoginViewModel model);
        public Task Logout();
    }
}
