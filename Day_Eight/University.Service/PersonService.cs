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
    public class PersonService : IPersonService
    {
        public PersonService()
        {
        }

        protected IPersonRepository Repository = new PersonRepository();

        public async Task<List<IPerson>> GetAllAsync(PersonFilter filtering, PersonSort sorting, Page paging)
        {
            return await Repository.GetAllAsync(filtering, sorting, paging);
        }

        public async Task<IPerson> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task PostAsync(IPerson person)
        {
            await Repository.PostAsync(person);
        }

        public async Task PutAsync(int id, IPerson person)
        {
            await Repository.PutAsync(id, person);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Repository.DeleteByIdAsync(id);
        }
    }
}
