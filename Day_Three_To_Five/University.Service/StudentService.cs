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

        protected IStudentRepository Repository = new StudentRepository();

        public async Task<List<Student>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task PostAsync(Student student)
        {
            await Repository.PostAsync(student);
        }

        public async Task PutAsync(int id, Student student)
        {
            await Repository.PutAsync(id, student);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Repository.DeleteByIdAsync(id);
        }
    }
}
