using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Specs
{
    public class Pagination<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool HasNext { get; set; }
        public bool HasPre { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}
