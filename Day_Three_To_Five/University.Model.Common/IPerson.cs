using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Model.Common
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string OIB { get; set; }
        string PlaceOfResidence { get; set; }
        string Address { get; set; }
        DateTime DateofBirth { get; set; }
        int StudentId { get; set; }
        IStudent student { get; set; }
    }

}
