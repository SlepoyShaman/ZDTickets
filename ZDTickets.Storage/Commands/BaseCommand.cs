namespace ZDTickets.Storage.Commands
{
    internal abstract class BaseCommand
    {
        public abstract Task Execute(AppDbContext context);
    }
}
