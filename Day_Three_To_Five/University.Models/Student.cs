using University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Model
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public string IndexNumber { get; set; }
        public string Course { get; set; }
    }
}
