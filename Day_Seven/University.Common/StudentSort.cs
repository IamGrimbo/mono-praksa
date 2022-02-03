using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Common
{
    public class StudentSort
    {
        public string SortBy { get; set; } = "course";
        public string SortOrder { get; set; } = "ASC";
        public string Sorting()
        {
            if ((SortBy == null && SortBy == "") || (SortOrder == null && SortOrder == ""))
                return String.Format("");

            return String.Format(" ORDER BY {0} {1}", SortBy, SortOrder);
        }
    }
}