using University.Model;
using University.Model.Common;
using University.Repository;
using University.Repository.Common;
using University.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service
{
    public class StudentService : IStudentService
    {
        public StudentService()
        {
        }

        protected IPersonRepository PersonRepository = new PersonRepository();
        protected IStudentRepository StudentRepository = new StudentRepository();

        public async Task<List<Student>> GetAllAsync()
        {
            List<Student> students = new List<Student>();
            List<Student> studentTableMergedWithPersonTable = new List<Student>();
            students = await StudentRepository.GetAllAsync();
            foreach (Student student in students)
            {
                Student newStudent = new Student();
                newStudent.person = new Person();
                Person person = new Person();
                newStudent.IndexNumber = student.IndexNumber;
                newStudent.Course = student.Course;
                person = await PersonRepository.GetByIdAsync(student.Id);
                newStudent.person = person;
                studentTableMergedWithPersonTable.Add(newStudent);
            }

            return studentTableMergedWithPersonTable;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await StudentRepository.GetByIdAsync(id);
        }

        public async Task PostAsync(Student student)
        {
            await StudentRepository.PostAsync(student);
        }

        public async Task PutAsync(int id, Student student)
        {
            await StudentRepository.PutAsync(id, student);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await StudentRepository.DeleteByIdAsync(id);
        }
    }
}
