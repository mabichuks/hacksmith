using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Models
{
    public class PageModel<T>
    {
        public PageModel(long pageNumber, long pageSize, T[] data, long totalCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Items = data;
            this.TotalCount = totalCount;
        }

        public long PageNumber { get; set; }
        public long PageSize { get; set; }
        public T[] Items { get; set; }
        public long TotalCount { get; set; }
    }
}
