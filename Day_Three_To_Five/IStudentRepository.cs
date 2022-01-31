using University.Model;
using University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Repository.Common
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<bool> PostAsync(Student student);
        Task<bool> PutAsync(int id, Student student);
        Task<bool> DeleteByIdAsync(int id);
    }
}
