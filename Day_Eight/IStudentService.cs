using University.Common;
using University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Common
{
    public interface IStudentService
    {
        Task<List<IStudent>> GetAllAsync(StudentFilter filtering, StudentSort sorting, Page paging);
        Task<IStudent> GetByIdAsync(int id);
        Task PostAsync(IStudent student);
        Task PutAsync(int id, IStudent student);
        Task DeleteByIdAsync(int id);
    }
}