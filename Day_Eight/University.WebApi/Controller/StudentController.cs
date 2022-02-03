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
    public class StudentController : ApiController
    {
        public StudentController() { }
        protected IStudentService Service = new StudentService();

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAsync([FromUri] StudentFilter filtering, [FromUri] StudentSort sorting, [FromUri] Page paging)
        {
            try
            {
                List<StudentViewModel> studentViewList = new List<StudentViewModel>();
                List<IStudent> studentList = await Service.GetAllAsync(filtering, sorting, paging);

                foreach (Student student in studentList)
                {
                    StudentViewModel studentViewModel = new StudentViewModel();
                    studentViewModel.IndexNumber = student.IndexNumber;
                    studentViewModel.Course = student.Course;
                    studentViewList.Add(studentViewModel);
                }

                return Request.CreateResponse(HttpStatusCode.OK, studentViewList);
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
                IStudent student = await Service.GetByIdAsync(id);
                StudentViewModel studentViewModel = new StudentViewModel();

                studentViewModel.IndexNumber = student.IndexNumber;
                studentViewModel.Course = student.Course;

                return Request.CreateResponse(HttpStatusCode.OK, studentViewModel);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync([FromBody] StudentViewModel student)
        {
            try
            {
                Student newStudent = new Student();
                await Service.PostAsync(newStudent);
                return Request.CreateResponse(HttpStatusCode.OK, "New student added!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody] StudentViewModel student)
        {
            try
            {
                Student newStudent = new Student();
                await Service.PutAsync(id, newStudent);
                return Request.CreateResponse(HttpStatusCode.OK, "Student updated!");
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
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
