using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Entity_Layer;

namespace Data_Layer
{
    public class Data
    {
        private readonly string _connectionString;
        SqlConnection connection;

        public Data()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dbContacts"].ToString();
            connection = new SqlConnection(_connectionString);
        }

        public List<Contacts> Populate(string searchParam)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("spPopulate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SearchParam", searchParam);
            SqlDataReader rows = cmd.ExecuteReader();

            List<Contacts> contacts = new List<Contacts>();
            while (rows.Read())
            {
                contacts.Add(new Contacts
                {
                    Id = rows.GetInt32(0),
                    Name = rows.GetString(1),
                    LastName = rows.GetString(2),
                    DateBirth = rows.GetDateTime(3),
                    Address = rows.GetString(4),
                    Gender = rows.GetString(5),
                    CivilState = rows.GetString(6),
                    MobileNum = rows.GetString(7),
                    PhoneNum = rows.GetString(8),
                    Email = rows.GetString(9)
                });
            }
            rows.Close();
            connection.Close();
            return contacts;
        }

        public List<Contacts> ListAllContacts()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM vwGetAllContacts", connection);
            SqlDataReader rows = cmd.ExecuteReader();

            List<Contacts> contacts = new List<Contacts>();
            while (rows.Read())
            {
                contacts.Add(new Contacts
                {
                    Id = rows.GetInt32(0),
                    Name = rows.GetString(1),
                    LastName = rows.GetString(2),
                    DateBirth = rows.GetDateTime(3),
                    Address = rows.GetString(4),
                    Gender = rows.GetString(5),
                    CivilState = rows.GetString(6),
                    MobileNum = rows.GetString(7),
                    PhoneNum = rows.GetString(8),
                    Email = rows.GetString(9)
                });
            }
            rows.Close();
            connection.Close();
            return contacts;
        }

        public void CreateContact(Contacts contact)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("spCreateContact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = contact.Name;
            cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = contact.LastName;
            cmd.Parameters.AddWithValue("@DateBirth", SqlDbType.Date).Value = contact.DateBirth;
            cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = contact.Address;
            cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = contact.Gender;
            cmd.Parameters.AddWithValue("@CivilState", SqlDbType.VarChar).Value = contact.CivilState;
            cmd.Parameters.AddWithValue("@MobileNum", SqlDbType.VarChar).Value = contact.MobileNum;
            cmd.Parameters.AddWithValue("@PhoneNum", SqlDbType.VarChar).Value = contact.PhoneNum;
            cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = contact.Email;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateContact(Contacts contact)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("spUpdateContact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = contact.Id;
            cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = contact.Name;
            cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = contact.LastName;
            cmd.Parameters.AddWithValue("@DateBirth", SqlDbType.Date).Value = contact.DateBirth;
            cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = contact.Address;
            cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = contact.Gender;
            cmd.Parameters.AddWithValue("@CivilState", SqlDbType.VarChar).Value = contact.CivilState;
            cmd.Parameters.AddWithValue("@MobileNum", SqlDbType.VarChar).Value = contact.MobileNum;
            cmd.Parameters.AddWithValue("@PhoneNum", SqlDbType.VarChar).Value = contact.PhoneNum;
            cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = contact.Email;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteContact(int Id)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("spDeleteContact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Id;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
