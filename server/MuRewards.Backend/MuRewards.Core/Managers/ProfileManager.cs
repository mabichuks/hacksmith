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
    public class ProfileManager : IProfileManager
    {
        private readonly IUnitOfWork _uow;
        public ProfileManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ResponseModel> GetProfileByEmail(string email)
        {
            try
            {
                var profile = await _uow.ProfileRepo.SingleOrDefaultAync(x => x.Email.ToLower() == email.ToLower());
                var response = profile.ToModel();

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
                    Message = "error occured when fetching profile"
                };
            }
        }
    }
}
