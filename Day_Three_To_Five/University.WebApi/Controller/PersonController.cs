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
        protected IPersonService Service = new PersonService();

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            try
            {
                List<PersonViewModel> personViewList = new List<PersonViewModel>();
                List<Person> personList = new List<Person>();
                personList = await Service.GetAllAsync();

                foreach (var person in personList)
                {
                    PersonViewModel personViewModel = new PersonViewModel();
                    personViewModel.FirstName = person.FirstName;
                    personViewModel.LastName = person.LastName;
                    personViewModel.Address = person.Address;
                    personViewModel.PlaceOfResidence = person.PlaceOfResidence;
                    personViewModel.DateOfBirth = person.DateOfBirth;
                    personViewList.Add(personViewModel);
                }

                return Request.CreateResponse(HttpStatusCode.OK, personViewList);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByIdAsync(int id)
        {
            try
            {
                PersonViewModel personViewModel = new PersonViewModel();
                Person person = new Person();

                person = await Service.GetByIdAsync(id);
                personViewModel.FirstName = person.FirstName;
                personViewModel.LastName = person.LastName;
                personViewModel.Address = person.Address;
                personViewModel.PlaceOfResidence = person.PlaceOfResidence;
                personViewModel.DateOfBirth = person.DateOfBirth;

                return Request.CreateResponse(HttpStatusCode.OK, personViewModel);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync([FromBody] PersonViewModel person)
        {
            try
            {
                Person newPerson = new Person();
                await Service.PostAsync(newPerson);
                return Request.CreateResponse(HttpStatusCode.OK, "New person added!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> PutAsync(int id, PersonViewModel person)
        {
            try
            {
                Person newPerson = new Person();
                await Service.PutAsync(id, newPerson);
                return Request.CreateResponse(HttpStatusCode.OK, "Person updated!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteByIdAsync(int id)
        {
            try
            {
                await Service.DeleteByIdAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Person deleted!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
