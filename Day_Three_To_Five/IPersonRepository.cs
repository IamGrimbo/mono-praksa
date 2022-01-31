using University.Model;
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
        Task<List<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task<bool> PostAsync(Person person);
        Task<bool> PutAsync(int id, Person person);
        Task<bool> DeleteByIdAsync(int id);
    }
}
