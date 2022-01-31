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
    public class PersonService : IPersonService
    {
        public PersonService()
        {
        }

        protected IPersonRepository Repository = new PersonRepository();

        public async Task<List<Person>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task<bool> PostAsync(Person person)
        {
            return await Repository.PostAsync(person);
        }

        public async Task<bool> PutAsync(int id, Person person)
        {
            return await Repository.PutAsync(id, person);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await Repository.DeleteByIdAsync(id);
        }

    }
}