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
    public class SpPersonDalNew:IPersonDal
    {
        public void Add(Person entity)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PersonDB;Integrated Security=True");

            SqlCommand command = new SqlCommand("SP_PersonInsert", connection);

            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PersonName", entity.PersonName);
            command.Parameters.AddWithValue("@PersonSurname", entity.PersonSurname);
            command.Parameters.AddWithValue("@Number", entity.Number);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Person entity)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PersonDB;Integrated Security=True");

            SqlCommand command = new SqlCommand("SP_PersonUpdate", connection);
            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PersonId", entity.PersonId);
            command.Parameters.AddWithValue("@PersonName", entity.PersonName);
            command.Parameters.AddWithValue("@PersonSurname", entity.PersonSurname);
            command.Parameters.AddWithValue("@Number", entity.Number);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Person entity)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PersonDB;Integrated Security=True");

            SqlCommand command = new SqlCommand("SP_PersonDelete", connection);

            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PersonId", entity.PersonId);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Person> GetAll(Expression<Func<Person, bool>> filter = null)
        {
            SqlConnection connection =
                new SqlConnection(
                    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PersonDB;Integrated Security=True");

            SqlCommand command = new SqlCommand("SP_ListPerson", connection);

            connection.Open(); 
            command.CommandType = CommandType.StoredProcedure;
           

            SqlDataAdapter adp = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Persons");

            List<Person> persons = new List<Person>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Person person = new Person()
                {
                    PersonId = Convert.ToInt32(ds.Tables[0].Rows[i][0]),
                    PersonName = ds.Tables[0].Rows[i][1].ToString(),
                    PersonSurname = ds.Tables[0].Rows[i][2].ToString(),
                    Number = Convert.ToInt64(ds.Tables[0].Rows[i][3])
                };
                persons.Add(person);
            }

            command.ExecuteNonQuery();
            connection.Close();

            return persons;
        }

        public Person Get(Expression<Func<Person, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
