﻿using Microsoft.EntityFrameworkCore;
using MuRewards.Core.Entities;
using MuRewards.Core.Interfaces;
using MuRewards.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Infrastructure.Repos
{
    public class WalletRepo : BaseRepository<MuWallet>, IWalletRepo
    {
        public MuRewardsContext Context => _context as MuRewardsContext;
        public WalletRepo(MuRewardsContext context) : base(context)
        {
        }

    }
}
