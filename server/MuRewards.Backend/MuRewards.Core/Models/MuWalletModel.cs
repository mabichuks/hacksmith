using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Models
{
    public class MuWalletModel
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public WalletType WalletType { get; set; }
        public decimal MuPoints { get; set; }
        public ProfileModel Profile { get; set; }
    }
}
