using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SchoolSubject : BestStudentAtSchoolSubject, ISchoolSubject
    {
		public SchoolSubject(string MsubjectName, int MamountOfStudentsTakingTheSubject, string MbestStudentAtThisSubject)
		{
			subjectName = MsubjectName;
			amountOfStudentsTakingTheSubject = MamountOfStudentsTakingTheSubject;
            bestStudentAtThisSubject = MbestStudentAtThisSubject;
		}

		public string subjectName { get; set; }

		public int amountOfStudentsTakingTheSubject { get; set; }

		public string bestStudentAtThisSubject { get; set; }

		public override void BestStudentAtThisSubject()
		{
			Console.WriteLine("Best Student at {0} is {1}", subjectName, bestStudentAtThisSubject);
		}
    }
}