using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZDTickets.Storage.Entities;

namespace ZDTickets.Storage
{
    internal class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TrainEntity> Trains => Set<TrainEntity>();
        public DbSet<TicketEntity> Tickets => Set<TicketEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TrainEntity>(entity =>
            {
                entity.HasKey(t => t.TrainId);
                entity.HasMany(t => t.Tickets)
                    .WithOne(t => t.Train)
                    .HasForeignKey(t => t.TrainId);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasMany(u => u.Tickets)
                    .WithOne(t => t.User)
                    .HasForeignKey(t => t.UserId);
            });

            builder.Entity<TicketEntity>(entity =>
            {
                entity.HasKey(t => t.TicketId);
            });
        }

    }
}
