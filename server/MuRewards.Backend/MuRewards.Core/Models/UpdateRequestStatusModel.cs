using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Models
{
    public class UpdateRequestStatusModel
    {
        public Guid RequestId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set;}
    }
}
