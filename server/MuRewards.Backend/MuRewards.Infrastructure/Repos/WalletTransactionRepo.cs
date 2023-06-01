using Microsoft.EntityFrameworkCore;
using MuRewards.Core.Entities;
using MuRewards.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Infrastructure.Repos
{
    public class WalletTransactionRepo : BaseRepository<WalletTransaction>, IWalletTransactionRepo
    {
        public MuRewardsContext Context => _context as MuRewardsContext;
        public WalletTransactionRepo(MuRewardsContext context) : base(context)
        {
        }
    }
}
