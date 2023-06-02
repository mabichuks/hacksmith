using MuRewards.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Interfaces
{
    public interface IRewardRequestManager
    {
        Task<ResponseModel> GetRewardsByManagerId(Guid managerId, string email = null, int page = 1, int pageSize = 10);
        Task<ResponseModel> UpdateRequestStatus(UpdateRequestStatusModel updateModel);
    }
}
