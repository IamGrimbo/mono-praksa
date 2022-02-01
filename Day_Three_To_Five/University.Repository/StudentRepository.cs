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

        public async Task<List<IStudent>> GetAllAsync()
        {
            List<IStudent> listOfStudents = new List<IStudent>();

            string queryString = "SELECT * FROM student";

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);
                SqlDataReader Reader = await Command.ExecuteReaderAsync();

                while (Reader.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(Reader["id"].ToString());
                    student.IndexNumber = Reader["indexNumber"].ToString();
                    student.Course = Reader["course"].ToString();
                    listOfStudents.Add(student);
                }

                Reader.Close();
                Connection.Close();
            }

            return listOfStudents;
        }

        public async Task<IStudent> GetByIdAsync(int id)
        {

            IStudent student = new Student();

            string queryString = "SELECT * FROM student WHERE id=" + id + ";";

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {

                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);
                SqlDataReader Reader = await Command.ExecuteReaderAsync();

                while (Reader.Read())
                {
                    student.Id = int.Parse(Reader["id"].ToString());
                    student.IndexNumber = Reader["indexNumber"].ToString();
                    student.Course = Reader["course"].ToString();
                }

                Reader.Close();
                Connection.Close();
            }

            return student;
        }

        public async Task PostAsync(IStudent student)
        {
            string queryString = "INSERT INTO student VALUES('" + student.IndexNumber + "','" + student.Course + "');";

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);

                await Command.ExecuteNonQueryAsync();
                Connection.Close();
            }
        }

        public async Task PutAsync(int id, IStudent student)
        {

            string queryString = "UPDATE student SET indexnumber='" + student.IndexNumber + "', course='" + student.Course + "'WHERE id='" + id + "');";

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);

                await Command.ExecuteNonQueryAsync();
                Connection.Close();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            string queryString = "DELETE FROM student WHERE id=" + id + ";";
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);

                await Command.ExecuteNonQueryAsync();
                Connection.Close();
            }
        }
    }
}
