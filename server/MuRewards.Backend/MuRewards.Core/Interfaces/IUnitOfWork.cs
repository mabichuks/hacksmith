using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Interfaces
{
    public interface IUnitOfWork
    {
        int Complete();
        Task<int> CompleteAsync();
    }
}
