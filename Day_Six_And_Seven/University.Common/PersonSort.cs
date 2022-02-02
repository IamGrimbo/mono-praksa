using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Common
{
    public class PersonSort
    {
        public string SortBy { get; set; } = "firstName";
        public string SortOrder { get; set; } = "ASC";
        public string Sorting()
        {
            if (SortBy == null || SortOrder == null)
                return String.Format("");

            return String.Format(" ORDER BY {0} {1}", SortBy, SortOrder);
        }
    }
}