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
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository() { }

        protected IPerson person = new Person();

        static string connectionString = "Server = localhost; Database = master; Trusted_Connection = True;";

        public async Task<List<IPerson>> GetAllAsync(PersonFilter filtering, PersonSort sorting, Page paging)
        {
            List<IPerson> listOfPeople = new List<IPerson>();

            string queryString = "SELECT * FROM person;" + filtering.Filtering() + sorting.Sorting() + paging.Paging();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Person person = new Person();
                    person.Id = int.Parse(reader["id"].ToString());
                    person.FirstName = reader["firstName"].ToString();
                    person.LastName = reader["lastName"].ToString();
                    person.Address = reader["residenceAddress"].ToString();
                    person.OIB = reader["oib"].ToString();
                    person.PlaceOfResidence = reader["placeOfResidence"].ToString();
                    person.DateOfBirth = DateTime.Parse(reader["dateOfBirth"].ToString());
                    person.StudentId = int.Parse(reader["studentId"].ToString());
                    listOfPeople.Add(person);
                }

                reader.Close();
                connection.Close();
            }

            return listOfPeople;
        }

        public async Task<IPerson> GetByIdAsync(int id)
        {

            IPerson person = new Person();
            string queryString = "SELECT * FROM person WHERE id=" + id + ";";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    person.Id = int.Parse(reader["id"].ToString());
                    person.FirstName = reader["firstName"].ToString();
                    person.LastName = reader["lastName"].ToString();
                    person.Address = reader["residenceAddress"].ToString();
                    person.OIB = reader["oib"].ToString();
                    person.PlaceOfResidence = reader["placeOfResidence"].ToString();
                    person.DateOfBirth = DateTime.Parse(reader["dateOfBirth"].ToString());
                    person.StudentId = int.Parse(reader["studentId"].ToString());
                }

                reader.Close();
                connection.Close();
            }

            return person;
        }

        public async Task PostAsync(IPerson person)
        {
            string queryString = "INSERT INTO person VALUES('" + person.FirstName + "','" + person.LastName + "','" + person.Address + "','" + person.OIB + "','" + person.PlaceOfResidence + "','" + person.DateOfBirth + "','" + person.StudentId + "'); ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);

                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task PutAsync(int id, IPerson person)
        {

            string queryString = "UPDATE person SET firstName='" + person.FirstName + "', lastName='" + person.LastName + "', residenceAddress='" + person.Address + "', oib='" + person.OIB + "', placeOfResidence='" + person.PlaceOfResidence + "', dateOfBrith='" + person.DateOfBirth + "', studentId='" + person.StudentId + "'); ";

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
            string queryString = "DELETE FROM person WHERE id=" + id + ";";
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
