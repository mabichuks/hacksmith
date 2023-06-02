using MuRewards.Core.Entities;
using MuRewards.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Infrastructure.Repos
{
    public class CatalogRepository : BaseRepository<Catalog>, ICatalogRepository
    {
        public MuRewardsContext Context => _context as MuRewardsContext;
        public CatalogRepository(MuRewardsContext context) : base(context)
        {
        }
    }
}
