using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Model.Common
{
    public interface IStudent
    {
        int Id { get; set; }
        string IndexNumber { get; set; }
        string Course { get; set; }
        IPerson person { get; set; }
    }
}
