using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Common
{
    public class PersonFilter
    {
        public string SearchBy { get; set; } = "";
        public string Querry { get; set; } = "";
        public string Filtering()
        {
            if ((SearchBy == null && SearchBy == "") || (Querry == null && Querry == ""))
                return String.Format("");

            return String.Format(" WHERE {0} LIKE '%{1}%'", SearchBy, Querry);
        }
    }
}
