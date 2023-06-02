using MuRewards.Core.Interfaces;
using MuRewards.Core.Models;
using MuRewards.Core.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MuRewards.Core.Managers
{
    public class RewardManager : IRewardRequestManager
    {
        private readonly IUnitOfWork _uow;
        public RewardManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ResponseModel> GetRewardsByManagerId(Guid managerId, string email = null, int page = 1, int pageSize = 10)
        {
            try
            {
                var allRewards = await _uow.RewardRequestRepo.GetAllAsync();

                var rewards = allRewards.Where(x => x.ManagerId == managerId);

                var pagedRewards = rewards.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var response = pagedRewards.Select(x => x.ToModel());

                return new ResponseModel
                {
                    Succeeded = true,
                    Data = response,
                    Message = "success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Succeeded = false,
                    Data = null,
                    Message = "error occured when fetching rewards"
                };
            }
        }

        public async Task<ResponseModel> UpdateRequestStatus(UpdateRequestStatusModel updateModel)
        {
            try
            {
                var request = await _uow.RewardRequestRepo.Get(updateModel.RequestId);
                if (request == null)
                {
                    return new ResponseModel
                    {
                        Succeeded = false,
                        Data = null,
                        Message = "Request not found"
                    };
                }

                request.Status = updateModel.Status;

                _uow.RewardRequestRepo.UpdateAsync(request);
                await _uow.CompleteAsync();

                return new ResponseModel
                {
                    Succeeded = true,
                    Data = request.ToModel(),
                    Message = "Request status updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Succeeded = false,
                    Data = null,
                    Message = $"Error occurred when updating request status: {ex.Message}"
                };
            }
        }
    }
}
