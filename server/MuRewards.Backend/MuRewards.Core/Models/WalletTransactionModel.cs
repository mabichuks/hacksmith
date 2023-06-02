using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Models
{
    public class WalletTransactionModel
    {
        public Guid Id { get; set; }
        public Guid MuWalletId { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public decimal MuPoints { get; set; }
        public MuWalletModel MuWallet { get; set; }
    }
}
