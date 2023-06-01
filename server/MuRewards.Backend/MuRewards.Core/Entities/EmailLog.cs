using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Entities
{
    public class EmailLog
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
