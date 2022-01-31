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
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository() { }

        protected Person person = new Person();

        static string connectionString = "Server = localhost; Database = master; Trusted_Connection = True;";

        public async Task<List<Person>> GetAllAsync()
        {
            List<Person> listOfPeople = new List<Person>();

            string queryString = "SELECT * FROM person";

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);
                SqlDataReader Reader = await Command.ExecuteReaderAsync();

                while (Reader.Read())
                {
                    Person person = new Person();
                    person.Id = int.Parse(Reader["id"].ToString());
                    person.FirstName = Reader["firstName"].ToString();
                    person.LastName = Reader["lastName"].ToString();
                    person.Address = Reader["residenceAddress"].ToString();
                    person.OIB = Reader["oib"].ToString();
                    person.PlaceOfResidence = Reader["placeOfResidence"].ToString();
                    person.DateofBirth = DateTime.Parse(Reader["dateOfBirth"].ToString());
                    person.StudentId = int.Parse(Reader["studentId"].ToString());
                    listOfPeople.Add(person);
                }
                Reader.Close();
                Connection.Close();
                return listOfPeople;
            }
        }

        public async Task<Person> GetByIdAsync(int id)
        {

            Person person = new Person();
            string queryString = "SELECT * FROM person;";

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {

                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);
                SqlDataReader Reader = await Command.ExecuteReaderAsync();

                while (Reader.Read())
                {
                    person.Id = int.Parse(Reader["id"].ToString());
                    person.FirstName = Reader["firstName"].ToString();
                    person.LastName = Reader["lastName"].ToString();
                    person.Address = Reader["residenceAddress"].ToString();
                    person.OIB = Reader["oib"].ToString();
                    person.PlaceOfResidence = Reader["placeOfResidence"].ToString();
                    person.DateofBirth = DateTime.Parse(Reader["dateOfBirth"].ToString());
                    person.StudentId = int.Parse(Reader["studentId"].ToString());
                }
                Reader.Close();
                Connection.Close();
                return person;
            }
        }

        public async Task PostAsync(Person person)
        {
            string queryString = "INSERT INTO person VALUES('" + person.FirstName + "','" + person.LastName + "','" + person.Address + "','" + person.OIB + "','" + person.PlaceOfResidence + "','" + person.DateofBirth + "','" + person.StudentId + "'); ";

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlCommand Command = new SqlCommand(queryString, Connection);

                await Command.ExecuteNonQueryAsync();
                Connection.Close();
            }
        }

        public async Task PutAsync(int id, Person person)
        {

            string queryString = "UPDATE person SET firstName='" + person.FirstName + "', lastName='" + person.LastName + "', residenceAddress='" + person.Address + "', oib='" + person.OIB + "', placeOfResidence='" + person.PlaceOfResidence + "', dateOfBrith='" + person.DateofBirth + "', studentId='" + person.StudentId + "'); ";

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
            string queryString = "DELETE FROM person WHERE id=" + id + ";";
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
