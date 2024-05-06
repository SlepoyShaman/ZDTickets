namespace ZDTickets.Logic.ViewModels
{
    public record RegisterViewModel(
         string Login,
         string Password,
         string ConfirmPassword);

    public record LoginViewModel(
        string Login,
        string Password);
}
