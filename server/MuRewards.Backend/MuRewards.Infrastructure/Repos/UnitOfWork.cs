using Microsoft.EntityFrameworkCore;
using MuRewards.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Infrastructure.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly MuRewardsContext _context;

        public IProfileRepo ProfileRepo => new ProfileRepo(_context);
        public IWalletRepo WalletRepo => new WalletRepo(_context);
        public IWalletTransactionRepo WalletTransactionRepo => new WalletTransactionRepo(_context);
        public IRewardRequestRepo RewardRequestRepo => new RewardRequestRepo(_context);
        public ICatalogRepository CatalogRepository => new CatalogRepository(_context);

        public UnitOfWork(MuRewardsContext context)
        {
            _context = context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
