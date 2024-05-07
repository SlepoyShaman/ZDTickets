using Microsoft.AspNetCore.Identity;
using ZDTickets.Logic.Abstractions;
using ZDTickets.Storage.Entities;

namespace ZDTickets.Storage.Identity
{
    internal class UserStorage : IUserStorage
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserStorage(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Register(string login, string password)
        {
            var user = new User() { UserName = login };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                if (result.Errors.Any(e => e.Code == "InvalidUserName"))
                    throw new ArgumentException("Имя пользователя может содержать только английские буквы или цифры");
                throw new ArgumentException($"Пользователь {login} уже существует");
            }

            await _signInManager.SignInAsync(user, false);
        }

        public async Task Login(string login, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(login, password, false, false);
            if (result.Succeeded) return;
            throw new ArgumentException("Неверный логин или пароль");
        }

        public Task Logout()
            => _signInManager.SignOutAsync();

        public async Task<string> GetIdByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName)
                ?? throw new KeyNotFoundException($"Пользователь с именем {userName} не найден");
            return user.Id;
        }
    }
}
