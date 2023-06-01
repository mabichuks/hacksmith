using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Models
{
    public  class RewardRequestModel
    {
        public Guid Id { get; set; }
        public Guid RequesterId { get; set; }
        public Guid AwardeeId { get; set; }
        public Guid ManagerId { get; set; }
        public string Comments { get; set; }
        public Status Status { get; set; }
        public int MuPoints { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
