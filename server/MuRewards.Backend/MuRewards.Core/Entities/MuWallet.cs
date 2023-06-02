using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Entities
{
    public class MuWallet 
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public string WalletType { get; set; }
        public decimal MuPoints { get; set; }
        public Profile Profile { get; set; }
    }
}
