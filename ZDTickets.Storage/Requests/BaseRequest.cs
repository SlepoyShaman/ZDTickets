namespace ZDTickets.Storage.Requests
{
    internal abstract class BaseRequest<T>
    {
        public abstract Task<T> Execute(AppDbContext context);
    }
}
