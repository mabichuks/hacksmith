using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MuRewards.Core.Interfaces;
using MuRewards.Core.Managers;
using MuRewards.Infrastructure;
using MuRewards.Infrastructure.Repos;
using System.Reflection;

namespace MuRewards.Api.Extensions
{
    public static class AppExtensions
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //repos
            services.AddDbContext<MuRewardsContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IProfileRepo, ProfileRepo>();
            services.AddScoped<IWalletTransactionRepo, WalletTransactionRepo>();
            services.AddScoped<IWalletRepo, WalletRepo>();
            services.AddScoped<IRewardRequestRepo, RewardRequestRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //managers
            services.AddScoped<IProfileManager, ProfileManager>();

        }

        public static string ToNigerianString(this string arg)
        {
            return $"Nigerian{arg}";
        }
    }
}
