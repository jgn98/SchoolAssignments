using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetParadise
{
    public class PetRepo
    {
        private readonly string ConnectionString;

        private List<Pet> pets = new List<Pet>();

        public PetRepo()
        {
            // Load all pet data from database via SQL statements and populate pet repository
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            pets = new List<Pet>();

            ConnectionString = config.GetConnectionString("MyDBConnection");
            // IMPLEMENT THIS!
        }

        public int Add(Pet pet)
        {
            // Add new pet to database and to repository
            // Return the database id of the pet

            int result = -1;

            // IMPLEMENT THIS!
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(
                           "INSERT INTO TREATMENT (Name, Type, Breed, DateOfBirth, Weight, OwnerId) " +
                           "VALUES (@Name, @Type, @Breed, @DateOfBirth, @Weight, @OwnerId); " +
                           "SELECT SCOPE_IDENTITY();", con))
                {
                    cmd.Parameters.AddWithValue("@Name", pet.Name);
                    cmd.Parameters.AddWithValue("@Type", pet.PetType);
                    cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                    cmd.Parameters.AddWithValue("@DateOfBirth", pet.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Weight", pet.Weight);

                }
            }

            return result;
        }
        public List<Pet> GetAll()
        {
            // Retrieve all pets from database

            List<Pet> result = new List<Pet>();

            // IMPLEMENT THIS!
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PetId, Name, Type, Breed, DateOfBirth, Weight FROM PET", con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pet pet = new Pet
                        {
                            PetId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            PetType = Enum.TryParse(reader.GetString(2), true, out PetType parsed) ? parsed : PetType.Invalid,
                            Breed = reader.GetString(3),
                            DateOfBirth = reader.IsDBNull(4) ? null : (DateOnly.FromDateTime((reader.GetDateTime(4)))),
                            Weight = reader.GetDouble(5)
                        };
                        {

                        };
                        result.Add(pet);
                    }
                }
            }

            return result;
        }
        public Pet GetById(int id)
        {
            // Get pet by id from database

            Pet result = null;

            // IMPLEMENT THIS!
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PetId, Name, Type, Breed, DateOfBirth, Weight FROM PET WHERE PetId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new Pet
                        {
                            PetId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            PetType = Enum.TryParse(reader.GetString(2), true, out PetType parsed) ? parsed : PetType.Invalid,
                            Breed = reader.GetString(3),
                            DateOfBirth = reader.IsDBNull(4) ? null : (DateOnly.FromDateTime((reader.GetDateTime(4)))),
                            Weight = reader.GetDouble(5)
                        };
                    }
                }
            }


            return result;
        }
        public void Update(Pet pet)
        {
            // Update existing pet on database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE PET SET Name = @Name, Type = @Type, Breed = @Breed, DateOfBirth = @DateOfBirth, Weight = @Weight WHERE PetId = @id", con);

            }
            // IMPLEMENT THIS!
        }
        public void Remove(Pet pet)
        {
            // Delete existing pet in database

            // IMPLEMENT THIS!
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM PET WHERE PetId = @id", con);
                cmd.Parameters.AddWithValue("@id", pet.PetId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
