using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PetParadise
{
    public class TreatmentRepo
    {
        private readonly string ConnectionString;
        private List<Treatment> treatments = new List<Treatment>();

        public TreatmentRepo()
        {
            // Load all treatment data from database via SQL statements and populate treatment repository
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            treatments = new List<Treatment>();

            ConnectionString = config.GetConnectionString("MyDBConnection");
            // IMPLEMENT THIS!
        }

        public int Add(Treatment treatment)
        {
            
            int result = -1;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(
                           "INSERT INTO TREATMENT (Service, Date, Charge, PetId) " +
                           "VALUES (@Service, @Date, @Charge, @PetId); " +
                           "SELECT SCOPE_IDENTITY();", con))
                {
                    cmd.Parameters.AddWithValue("@Service", treatment.Service);
                    cmd.Parameters.AddWithValue("@Date", treatment.Date);
                    cmd.Parameters.AddWithValue("@Charge", treatment.Charge);
                }
            }
            
            return result;
        }
        public List<Treatment> GetAll()
        {
            // Retrieve all treatments from database
            List<Treatment> result = new List<Treatment>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TreatmentId, Service, Date, Charge, PetId FROM TREATMENT", con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Treatment treatment = new Treatment
                        {
                            TreatmentId = reader.GetInt32(0),
                            Service = reader.GetString(1),
                            Date = reader.IsDBNull(2) ? null : (DateOnly.FromDateTime((reader.GetDateTime(2)))),
                            Charge = reader.GetDouble(3)
                        };
                        result.Add(treatment);
                    }
                }
            }
            // IMPLEMENT THIS!

            return result;
        }
        public Treatment GetById(int id)
        {
            // Get treatment by id from database

            Treatment result = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TreatmentId, Service, Date, Charge, PetId FROM TREATMENT WHERE TreatmentId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new Treatment
                        {
                            TreatmentId = reader.GetInt32(0),
                            Service = reader.GetString(1),
                            Date = reader.IsDBNull(2) ? null : (DateOnly.FromDateTime((reader.GetDateTime(2)))),
                            Charge = reader.GetDouble(3)
                        };
                    }
                }
            }
            // IMPLEMENT THIS!

            return result;
        }
        public void Update(Treatment treatment)
        {
            // Update existing treatment on database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE TREATMENT SET Service = @Service, Date = @Date, Charge = @Charge, PetId = @PetId WHERE TreatmentId = @id", con);

            }
            // IMPLEMENT THIS!
        }
        public void Remove(Treatment treatment)
        {
            // Delete existing treatment in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM TREATMENT WHERE TreatmentId = @id", con);
                cmd.Parameters.AddWithValue("@id", treatment.TreatmentId);
                cmd.ExecuteNonQuery();
            }
            // IMPLEMENT THIS!
        }
    }
}
