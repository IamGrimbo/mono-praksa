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

        protected Student student = new Student();

        static string connecitonString = "Server = localhost; Database = master; Trusted_Connection = True;";

        public async Task<List<Student>> GetAllAsync()
        {
            List<Student> listOfStudents = new List<Student>();

            string queryString = "SELECT * FROM student";

            using (SqlConnection Connection = new SqlConnection(connecitonString))
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);
                SqlDataReader Reader = Command.ExecuteReader();

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
                return listOfStudents;
            }
        }

        public async Task<Student> GetByIdAsync(int id)
        {

            Student student = new Student();

            string queryString = "SELECT * FROM student WHERE id=" + id + ";";

            using (SqlConnection Connection = new SqlConnection(connecitonString))
            {

                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    student.Id = int.Parse(Reader["id"].ToString());
                    student.IndexNumber = Reader["indexNumber"].ToString();
                    student.Course = Reader["course"].ToString();
                }
                Reader.Close();
                Connection.Close();
                return student;
            }
        }

        public async Task<bool> PostAsync(Student student)
        {
            string queryString = "INSERT INTO student VALUES('" + student.IndexNumber + "','" + student.Course + "');";

            using (SqlConnection Connection = new SqlConnection(connecitonString))
            {
                try
                {
                    Connection.Open();
                    SqlCommand Command = new SqlCommand(queryString, Connection);

                    Command.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (SqlException sqlException)
                {
                    return false;
                }
            }
        }

        public async Task<bool> PutAsync(int id, Student student)
        {

            string queryString = "UPDATE student SET indexnumber='" + student.IndexNumber + "', indexnumber='" + student.Course + "'WHERE id='" + id + "');";

            using (SqlConnection Connection = new SqlConnection(connecitonString))
            {
                try
                {
                    Connection.Open();
                    SqlCommand Command = new SqlCommand(queryString, Connection);

                    Command.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (SqlException sqlException)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            string queryString = "DELETE FROM student WHERE id=" + id + ";";
            using (SqlConnection Connection = new SqlConnection(connecitonString))
            {
                try
                {
                    Connection.Open();
                    SqlCommand Command = new SqlCommand(queryString, Connection);
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (SqlException sqlException)
                {
                    return false;
                }
            }
        }
    }
}