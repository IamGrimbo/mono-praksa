using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Common
{
    public class Page
    {
        public int ItemsPerPage { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string Paging()
        {
            if (PageNumber == 0 && ItemsPerPage == 0)
                return String.Format("");

            int Offset = (PageNumber - 1) * ItemsPerPage;

            return String.Format(" OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", Offset, ItemsPerPage);
        }
    }
}
