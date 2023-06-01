using Microsoft.EntityFrameworkCore;
using MuRewards.Core.Entities;

namespace MuRewards.Infrastructure
{
    public class MuRewardsContext : DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        public DbSet<MuWallet> MuWallets { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<RewardRequest> RewardRequests { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        public MuRewardsContext(DbContextOptions context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}