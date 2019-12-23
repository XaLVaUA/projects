using Auction.BLL.Interfaces.Services;
using Auction.BLL.Services;
using Auction.DAL.EF;
using Auction.DAL.Interfaces.UnitOfWorks;
using Auction.DAL.Models;
using Auction.DAL.UnitOfWorks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.BLL
{
    public class InjectionResolver
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuctionContext>(config => 
                        config
                            .UseLazyLoadingProxies()
                            .UseSqlServer(connectionString)
                );

            services
                .AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<AuctionContext>();

            services.AddScoped<IAuctionUnitOfWork, AuctionUnitOfWork>();

            services.AddScoped<ILotService, LotService>();
            services.AddScoped<IBetService, BetService>();
        }
    }
}