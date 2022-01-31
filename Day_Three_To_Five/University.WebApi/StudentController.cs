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
        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            List<StudentViewModel> studentViewList = new List<StudentViewModel>();
            List<Student> studentList = new List<Student>();
            studentList = await Service.GetAllAsync();

            foreach (var student in studentList)
            {
                StudentViewModel studentViewModel = new StudentViewModel();
                studentViewModel.IndexNumber = student.IndexNumber;
                studentViewModel.Course = student.Course;
                studentViewList.Add(studentViewModel);
            }
            return studentViewList;
        }

        [HttpGet]
        public async Task<StudentViewModel> GetByIdAsync(int id)
        {
            Student student = new Student();
            student = await Service.GetByIdAsync(id);

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.IndexNumber = student.IndexNumber;
            studentViewModel.Course = student.Course;
            
            return studentViewModel;
        }

        [HttpPost]
        public async Task<bool> PostAsync(Student student)
        {
            return await Service.PostAsync(student);
        }

        [HttpPut]
        public async Task<bool> PutAsync(int id, Student student)
        {
            return await Service.PutAsync(id, student);
        }

        [HttpDelete]
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await Service.DeleteByIdAsync(id);
        }

    }
}