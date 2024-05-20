using Microsoft.EntityFrameworkCore;
using ZDTickets.Logic.Models;
using ZDTickets.Logic.ViewModels;

namespace ZDTickets.Storage.Requests
{
    internal class GetTrainsAsync : BaseRequest<TrainSummary[]>
    {
        private readonly TrainsFilter _filter;
        public GetTrainsAsync(TrainsFilter filter)
        {
            _filter = filter;
        }
        public override Task<TrainSummary[]> Execute(AppDbContext context)
        {
            var query = context.Trains
                .AsNoTracking();

            if (_filter.FromCity is not null)
                query = query.Where(t => EF.Functions.ILike(t.From, $"%{_filter.FromCity}%"));
            if (_filter.ToCity is not null)
                query = query.Where(t => EF.Functions.ILike(t.To, $"%{_filter.ToCity}%"));
            if (_filter.Date.HasValue)
            {
                var utcDate = _filter.Date.Value.ToUniversalTime();
                query = query.Where(t => t.DepartureTime.Date == utcDate.Date);
            }

            var take = _filter.PageSize > 1 ? _filter.PageSize : 10;
            var number = _filter.PageNumber > 0 ? _filter.PageNumber : 1;
            var skip = (number - 1) * take;
            return query.OrderBy(t => t.DepartureTime)
                .Skip(skip)
                .Take(take)
                .Select(t => new TrainSummary()
                {
                    Id = t.TrainId,
                    DepartureTime = t.DepartureTime,
                    ArrivalTime = t.ArrivalTime,
                    From = t.From,
                    To = t.To,
                })
                .ToArrayAsync();
        }
    }
}
