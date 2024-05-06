namespace ZDTickets.Logic.Abstractions
{
    public interface IUserStorage
    {
        public Task Register(string login, string password);
        public Task Login(string login, string password);
        public Task Logout();

        public Task<string> GetIdByUserName(string userName);
    }
}
