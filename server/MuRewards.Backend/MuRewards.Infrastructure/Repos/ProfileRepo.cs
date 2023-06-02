using Microsoft.EntityFrameworkCore;
using MuRewards.Core.Entities;
using MuRewards.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Infrastructure.Repos
{
    public class ProfileRepo : BaseRepository<Profile>, IProfileRepo
    {
        public MuRewardsContext Context => _context as MuRewardsContext;
        public ProfileRepo(MuRewardsContext context) : base(context)
        {
        }
    }
}
