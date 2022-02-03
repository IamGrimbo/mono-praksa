using University.Common;
using University.Model;
using University.Model.Common;
using University.Service;
using University.Service.Common;
using System;
using System.Collections.Generic;
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
        public async Task<HttpResponseMessage> GetAllAsync([FromUri] PersonFilter filtering, [FromUri] PersonSort sorting, [FromUri] Page paging)
        {
            try
            {
                List<PersonViewModel> personViewList = new List<PersonViewModel>();
                List<IPerson> personList = await Service.GetAllAsync(filtering, sorting, paging);

                foreach (Person person in personList)
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
                IPerson person = await Service.GetByIdAsync(id);
                PersonViewModel personViewModel = new PersonViewModel();

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
                IPerson newPerson = new Person();
                await Service.PostAsync(newPerson);
                return Request.CreateResponse(HttpStatusCode.OK, "New person added!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody] PersonViewModel person)
        {
            try
            {
                IPerson newPerson = new Person();
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