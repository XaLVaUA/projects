using Auction.DAL.EF.Configurations;
using Auction.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auction.DAL.EF
{
    public class AuctionContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Lot> Lots { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public AuctionContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LotConfiguration());
            builder.ApplyConfiguration(new BetConfiguration());
        }
    }
}