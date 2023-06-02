using MuRewards.Core.Interfaces;
using MuRewards.Core.Models;
using MuRewards.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Managers
{
    public class CatalogManager : ICatalogManager
    {
        private readonly IUnitOfWork _uow;
        public CatalogManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ResponseModel> Checkout(CartModel cart)
        {

            try
            {
                var wallet = await _uow.WalletRepo.SingleOrDefaultAync(x => x.ProfileId == Guid.Parse(cart.UserId) && x.WalletType == WalletType.User.ToString());

                if (wallet == null)
                {
                    return new ResponseModel
                    {
                        Data = null,
                        Message = "wallet not found",
                        Succeeded = false
                    };
                }

                //get items from db
                var itemIds = cart.Items.Select(x => x.ItemId).ToList();
                var items = _uow.CatalogRepository
                    .Find(x => itemIds.Contains(x.Id.ToString()))
                    .Join(cart.Items, cat => cat.Id.ToString(), item => item.ItemId, 
                            (cat, item) => new
                    {
                        cat.ItemName,
                        cat.Details,
                        item.Quantity,
                        cat.Value

                    });

                var totalItemPoints = 0;

                foreach(var item in items)
                {
                    var points = item.Value * item.Quantity;
                    totalItemPoints += points;
                }

                if(wallet.MuPoints < totalItemPoints)
                {
                    return new ResponseModel
                    {
                        Data = null,
                        Message = "Insufficient MuPoints",
                        Succeeded = false
                    };
                }

                wallet.MuPoints = wallet.MuPoints - totalItemPoints;
                await _uow.CompleteAsync();

                // send mail for purchase

                return new ResponseModel
                {
                    Data = null,
                    Message = "Mupoints redeem successful",
                    Succeeded = true
                };

            }
            catch (Exception ex)
            {

                return new ResponseModel
                {
                    Data = null,
                    Message = "unable to complete request",
                    Succeeded = false
                };
            }  
        }

        public async Task<ResponseModel> GetCatalog()
        {
            try
            {
                var result = await _uow.CatalogRepository
                                            .GetAllAsync();
                var response = result.Select(x => x.ToModel()).ToList();

                return new ResponseModel
                {
                    Data = response,
                    Message = "success",
                    Succeeded = true
                };

            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Data = null,
                    Message = "unable to complete request",
                    Succeeded = false
                };
            }
        }
    }
}
