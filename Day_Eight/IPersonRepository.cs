using University.Common;
using University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Repository.Common
{
    public interface IPersonRepository
    {
        Task<List<IPerson>> GetAllAsync(PersonFilter filtering, PersonSort sorting, Page paging);
        Task<IPerson> GetByIdAsync(int id);
        Task PostAsync(IPerson person);
        Task PutAsync(int id, IPerson person);
        Task DeleteByIdAsync(int id);
    }
}