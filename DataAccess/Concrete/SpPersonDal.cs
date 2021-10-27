using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Concrete
{
    public class SpPersonDal : IPersonDalNew
    {
        public void Add(string name, string surname, long number)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PersonDB;Integrated Security=True");

            SqlCommand command = new SqlCommand("SP_PersonInsert", connection);

            connection.Open();
            //command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "SP_PersonInsert";
            command.Parameters.AddWithValue("@PersonName", name);
            command.Parameters.AddWithValue("@PersonSurname", surname);
            command.Parameters.AddWithValue("@Number", number);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PersonDB;Integrated Security=True");

            SqlCommand command = new SqlCommand("SP_PersonDelete", connection);

            connection.Open();
           // command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "SP_PersonDelete";
            command.Parameters.AddWithValue("@PersonId", id);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(int id, string name, string surname, long number)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonDB;Integrated Security=True;");

            SqlCommand command = new SqlCommand("SP_PersonUpdate", connection);

            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PersonId", id);
            command.Parameters.AddWithValue("@PersonName", name);
            command.Parameters.AddWithValue("@PersonSurname", surname);
            command.Parameters.AddWithValue("@number", number);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Person> GetAll()
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PersonDB;Integrated Security=True");

            SqlCommand command = new SqlCommand("SP_ListPerson", connection);

            connection.Open();
            //command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "SP_ListPerson";

            SqlDataAdapter adp = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Persons");

            List<Person> persons = new List<Person>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Person person = new Person()
                {
                    PersonId = Convert.ToInt32(ds.Tables[0].Rows[i][0]), PersonName = ds.Tables[0].Rows[i][1].ToString(),
                    PersonSurname = ds.Tables[0].Rows[i][2].ToString(), Number = Convert.ToInt64(ds.Tables[0].Rows[i][3])
                };
                persons.Add(person);
            }

            command.ExecuteNonQuery();
            connection.Close();

            return persons;
        }
    }
}
