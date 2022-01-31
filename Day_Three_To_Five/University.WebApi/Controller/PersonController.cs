using University.Model.Common;
using University.Service;
using University.Service.Common;
using System;
using System.Collections.Generic;
using University.Model;
using University.Webapi.Model;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace University.WebApi.Controllers
{
    public class PersonController : ApiController
    {
        public PersonController() { }
        protected PersonService Service = new PersonService();

        [HttpGet]
        public async Task<List<PersonViewModel>> GetAllAsync()
        {
            List<PersonViewModel> personViewList = new List<PersonViewModel>();
            List<Person> personList = new List<Person>();
            personList = await Service.GetAllAsync();

            foreach (var person in personList)
            {
                PersonViewModel personViewModel = new PersonViewModel();
                personViewModel.FirstName = person.FirstName;
                personViewModel.LastName = person.LastName;
                personViewModel.OIB = person.OIB;
                personViewModel.PlaceOfResidence = person.PlaceOfResidence;
                personViewModel.DateofBirth = person.DateofBirth;
                personViewModel.StudentId = person.StudentId;
                personViewList.Add(personViewModel);
            }
            return personViewList;
        }

        [HttpGet]
        public async Task<PersonViewModel> GetByIdAsync(int id)
        {
            PersonViewModel personViewModel = new PersonViewModel();
            Person person = new Person();

            person = await Service.GetByIdAsync(id);
            personViewModel.FirstName = person.FirstName;
            personViewModel.LastName = person.LastName;
            personViewModel.OIB = person.OIB;
            personViewModel.PlaceOfResidence = person.PlaceOfResidence;
            personViewModel.DateofBirth = person.DateofBirth;
            personViewModel.StudentId = person.StudentId;

            return personViewModel;
        }

        [HttpPost]
        public async Task<bool> PostAsync(Person person)
        {
            return await Service.PostAsync(person);
        }

        [HttpPut]
        public async Task<bool> PutAsync(int id, Person person)
        {
            return await Service.PutAsync(id, person);
        }

        [HttpDelete]
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await Service.DeleteByIdAsync(id);
        }

    }
}
