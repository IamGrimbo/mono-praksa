using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1
{

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }


    public class StudentController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student(){ Id = 1, Name="Antun"},
            new Student(){ Id = 2, Name="Leon"},
            new Student(){ Id = 3, Name="Ivana"},
            new Student(){ Id = 4, Name="Stefan"},
            new Student(){ Id = 5, Name="Anamarija"}
        };


        [HttpGet]
        public HttpResponseMessage GetAllStudents()
        {
            if (students.Count == 0)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Students do not exist!");
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        [HttpGet]
        public HttpResponseMessage GetStudentById(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                    return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with that ID does not exist!");
        }

        [HttpPost]
        public HttpResponseMessage AddNewStudent(Student stud)
        {

            students.Add(stud);

            return Request.CreateResponse(HttpStatusCode.OK, "Student successfuly added!");
        }

        [HttpPut]
        public HttpResponseMessage PutStudent(int id, Student stud)
        {

            var student = new Student();

            if (students.Any(p => p.Id == id))
            {
                student = students.Where(p => p.Id == id).FirstOrDefault();
                student.Name = stud.Name;
                return Request.CreateResponse(HttpStatusCode.OK, students);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with that ID does not exist and therefore cannot be updated!");

        }

        [HttpDelete]
        public HttpResponseMessage DeleteStudentById(int id)
        {
            var student = new Student();

            if (id <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not a valid ID!");

            if (students.Any(p => p.Id == id))
            {
                student = students.Where(p => p.Id == id).FirstOrDefault();
                students.Remove(student);
                return Request.CreateResponse(HttpStatusCode.OK, students);

            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student was not found!");
        }


    }
}