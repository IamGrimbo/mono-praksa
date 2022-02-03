using University.Common;
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

        public async Task<List<IStudent>> GetAllAsync(StudentFilter filtering, StudentSort sorting, Page paging)
        {
            return await Repository.GetAllAsync(filtering, sorting, paging);
        }

        public async Task<IStudent> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task PostAsync(IStudent student)
        {
            await Repository.PostAsync(student);
        }

        public async Task PutAsync(int id, IStudent student)
        {
            await Repository.PutAsync(id, student);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Repository.DeleteByIdAsync(id);
        }
    }
}