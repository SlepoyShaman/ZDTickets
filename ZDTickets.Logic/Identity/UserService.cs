using ZDTickets.Logic.Abstractions;
using ZDTickets.Logic.ViewModels;

namespace ZDTickets.Logic.Identity
{
    internal class UserService : IUserService
    {
        private const int _minLoginLenght = 5;
        private const int _minPasswordLenght = 5;
        private readonly IUserStorage _userStorage;
        public UserService(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public Task Register(RegisterViewModel model)
        {
            if (model.Login.Length < _minLoginLenght)
                throw new ArgumentException($"Минимальная длина логина {_minLoginLenght}");
            if (model.Password.Length < _minPasswordLenght)
                throw new ArgumentException($"Минимальная длина пароля {_minPasswordLenght}");
            if (model.Password != model.ConfirmPassword)
                throw new ArgumentException($"Пароли не совпадают");

            return _userStorage.Register(model.Login, model.Password);
        }

        public Task Login(LoginViewModel model)
            => _userStorage.Login(model.Login, model.Password);
        public Task Logout()
            => _userStorage.Logout();

    }
}
