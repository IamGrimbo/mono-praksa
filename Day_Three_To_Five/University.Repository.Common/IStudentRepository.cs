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
        Task<List<IStudent>> GetAllAsync();
        Task<IStudent> GetByIdAsync(int id);
        Task PostAsync(IStudent student);
        Task PutAsync(int id, IStudent student);
        Task DeleteByIdAsync(int id);
    }
}
