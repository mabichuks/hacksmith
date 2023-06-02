using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProfileRepo ProfileRepo { get; }
        IWalletRepo WalletRepo { get; }
        IWalletTransactionRepo WalletTransactionRepo { get; }
        IRewardRequestRepo RewardRequestRepo { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
