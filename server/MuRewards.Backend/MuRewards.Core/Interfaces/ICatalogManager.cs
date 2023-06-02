using MuRewards.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Interfaces
{
    public interface ICatalogManager
    {
        Task<ResponseModel> GetCatalog();
        Task<ResponseModel> Checkout(CartModel cart);
    }
}
