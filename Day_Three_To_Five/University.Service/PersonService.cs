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

        protected IPersonRepository PersonRepository = new PersonRepository();
        protected IStudentRepository StudentRepository = new StudentRepository();

        public async Task<List<Person>> GetAllAsync()
        {
            List<Person> people = new List<Person>();
            List<Person> personTableMergedWithStudentTable = new List<Person>();
            people = await PersonRepository.GetAllAsync();
            foreach (Person person in people)
            {
                Person newPerson = new Person();
                newPerson.student = new Student();
                Student student = new Student();
                newPerson.FirstName = person.FirstName;
                newPerson.LastName = person.LastName;
                newPerson.Address = person.Address;
                newPerson.PlaceOfResidence = person.PlaceOfResidence;
                newPerson.DateofBirth = person.DateofBirth;
                student = await StudentRepository.GetByIdAsync(student.Id);
                newPerson.student = student;
                personTableMergedWithStudentTable.Add(newPerson);
            }

            return personTableMergedWithStudentTable;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await PersonRepository.GetByIdAsync(id);
        }

        public async Task PostAsync(Person person)
        {
            await PersonRepository.PostAsync(person);
        }

        public async Task PutAsync(int id, Person person)
        {
            await PersonRepository.PutAsync(id, person);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await PersonRepository.DeleteByIdAsync(id);
        }

    }
}
