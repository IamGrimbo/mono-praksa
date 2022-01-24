using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static double AverageSubjectMark(ISchoolSubject Subject)
        {
            int sum = 0;
            List<Student> students = new List<Student>();

            Random random = new Random();

            for (int i = Subject.amountOfStudentsTakingTheSubject; i > 0; i--)
            {
                students.Add(new Student() { mark = random.Next(1, 6) });
            }

            foreach (Student student in students)
            {
                sum += student.mark;
            }

            return (double)sum / (double)Subject.amountOfStudentsTakingTheSubject;
        }
        static void PrintSubjectAverageGrade(ISchoolSubject Subject)
        {
            Console.WriteLine("Total amount ff students taking {0} is {1}", Subject.subjectName, Subject.amountOfStudentsTakingTheSubject);
        }
        static void Main(string[] args)
        {
            ISchoolSubject Math = new SchoolSubject("Math", 27, "Ana");
            double averageSubjectMark = AverageSubjectMark(Math);
            
            PrintSubjectAverageGrade(Math);
            Console.WriteLine("Average Grade for {0} is {1}", Math.subjectName, averageSubjectMark);
        }
    }
}
