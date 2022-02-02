using University.Common;
using University.Model;
using University.Model.Common;
using University.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace University.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository() { }

        protected IStudent student = new Student();

        static string connectionString = "Server = localhost; Database = master; Trusted_Connection = True;";

        public async Task<List<IStudent>> GetAllAsync(StudentFilter filtering, StudentSort sorting, Page paging)
        {
            List<IStudent> listOfStudents = new List<IStudent>();

            string queryString = "SELECT * FROM student;" + filtering.Filtering() + sorting.Sorting() + paging.Paging();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(reader["id"].ToString());
                    student.IndexNumber = reader["indexNumber"].ToString();
                    student.Course = reader["course"].ToString();
                    listOfStudents.Add(student);
                }

                reader.Close();
                connection.Close();
            }

            return listOfStudents;
        }

        public async Task<IStudent> GetByIdAsync(int id)
        {

            IStudent student = new Student();

            string queryString = "SELECT * FROM student WHERE id=" + id + ";";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    student.Id = int.Parse(reader["id"].ToString());
                    student.IndexNumber = reader["indexNumber"].ToString();
                    student.Course = reader["course"].ToString();
                }

                reader.Close();
                connection.Close();
            }

            return student;
        }

        public async Task PostAsync(IStudent student)
        {
            string queryString = "INSERT INTO student VALUES('" + student.IndexNumber + "','" + student.Course + "');";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);

                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task PutAsync(int id, IStudent student)
        {

            string queryString = "UPDATE student SET indexnumber='" + student.IndexNumber + "', course='" + student.Course + "'WHERE id='" + id + "');";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);

                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            string queryString = "DELETE FROM student WHERE id=" + id + ";";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);

                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }
    }
}
