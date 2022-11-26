using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.Spesification
{
    public class ProductParams
    {
        public string? Sort { get; set; }
        public string? city { get; set; }

        private const int pageMaxSize = 10;

        public int PageIndex { get; set; } = 1;
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > pageMaxSize ? pageMaxSize : value; }
        }



    }
}
