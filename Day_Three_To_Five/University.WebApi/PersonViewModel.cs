using University.Model;
using University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Webapi.Model
{
    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }
        public string PlaceOfResidence { get; set; }
        public DateTime DateofBirth { get; set; }
        public int StudentId { get; set; }
    }
}