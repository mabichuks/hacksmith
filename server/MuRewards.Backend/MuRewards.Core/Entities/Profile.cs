using MuRewards.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Entities
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsManager { get; set; }
        public string? ManagerId { get; set; }
        public DateTime DoB { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
