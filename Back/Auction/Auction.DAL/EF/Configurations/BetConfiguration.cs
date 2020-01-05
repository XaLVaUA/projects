using Auction.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.DAL.EF.Configurations
{
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder
                .HasOne(b => b.Lot)
                .WithMany(l => l.Bets)
                .HasForeignKey(b => b.LotId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}