using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Models
{
    public class CatalogModel
    {
        public Guid Id { get; set; }
        public int ItemCount { get; set; }
        public string ItemName { get; set; }
        public string Details { get; set; }
        public int Value { get; set; }
        public string ImageUrl { get; set; }
    }
}
