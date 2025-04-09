using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PetParadise
{
    public class OwnerRepo
    {
        private readonly string ConnectionString;
 
        private List<Owner> owners = new List<Owner>();

        public OwnerRepo()
        {
            // Load all owner data from database via SQL statements and populate owner repository
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            owners = new List<Owner>();

            ConnectionString = config.GetConnectionString("MyDBConnection");
            // IMPLEMENT THIS!
        }

        public int Add(Owner owner)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd =
                       new SqlCommand(
                           "INSERT INTO OWNER (OwnerId, FirstName, LastName, Phone, Email" +
                           "VALUES (@OwnerId, @FirstName, @LastName, @Phone, @Email)" + "SELECT @@IDENTITY", con));
            }
            // Add new owner to database and to repository
            // Return the database id of the owner

            int result = -1;
            
            return result;
        }
        public List<Owner> GetAll()
        {
            // Retrieve all owners from database

            List<Owner> result = new List<Owner>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT OwnerId, FirstName, LastName, Phone, Email FROM OWNER", con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Owner owner = new Owner
                        {
                            OwnerId = reader.GetInt32(0),
                            FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                            LastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Phone = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Email = reader.IsDBNull(4) ? null : reader.GetString(4)
                        };
                        result.Add(owner);
                    }
                }
            }
            return result;
        }
        public Owner GetById(int id)
        {
            // Get owner by id from database

            Owner result = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT OwnerId, FirstName, LastName, Phone, Email FROM OWNER WHERE OwnerId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new Owner
                        {
                            OwnerId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Email = reader.GetString(4)
                        };
                    }
                }
            }
            return result;
        }
        public void Update(Owner owner)
        {
            // Update existing owner on database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE OWNER SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Email = @Email WHERE OwnerId = @id", con);
                
                cmd.Parameters.Add("@FirstName",SqlDbType.NVarChar).Value = owner.FirstName;
                cmd.Parameters.Add("@LastName",SqlDbType.NVarChar).Value = owner.LastName;
                cmd.Parameters.Add("@Phone",SqlDbType.NVarChar).Value = owner.Phone;
                cmd.Parameters.Add("@Email",SqlDbType.NVarChar).Value = owner.Email;
                cmd.ExecuteNonQuery();
            }
            
        }
        public void Remove(Owner owner)
        {
            // Delete existing owner in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM OWNER WHERE OwnerId = @id", con);
                cmd.Parameters.AddWithValue("@id", owner.OwnerId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
