using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Models
{
    public class CartModel
    {
        public string UserId { get; set; }
        public ItemModel[] Items { get; set; }
    }

    public class ItemModel
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
    }


}
