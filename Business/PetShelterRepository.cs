using Entity;
using Exceptions;
using System;
using DbConnection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Business
{
    public class PetShelterRepository : IPetShelter
    {
        public bool AddPet(Pet pet)
        {
            try
            {
                using SqlConnection connection = DBConnection.GetConnection();
                // Insert pet details into the database
                var command = new SqlCommand("INSERT INTO Pet (Name, Age, Breed) VALUES (@Name, @Age, @Breed)", connection);
                command.Parameters.AddWithValue("@Name", pet.Name);
                command.Parameters.AddWithValue("@Age", pet.Age);
                command.Parameters.AddWithValue("@Breed", pet.Breed);
                return command.ExecuteNonQuery() > 0; // Return true if one or more rows are affected
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool RemovePet(Pet pet)
        {
            try
            {
                using SqlConnection connection = DBConnection.GetConnection();
                // Delete pet by ID from the database
                var command = new SqlCommand("DELETE FROM Pet WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", pet.Id);
                return command.ExecuteNonQuery() > 0; // Return true if one or more rows are affected
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public List<Pet> ListAvailablePets()
        {
            var allPets = new List<Pet>();
            try
            {
                using SqlConnection connection = DBConnection.GetConnection();
                // Select all pets from the database
                var command = new SqlCommand("SELECT * FROM Pet", connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Add each pet to the list
                    allPets.Add(new Pet(
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetString(3))
                    {
                        Id = reader.GetInt32(0)
                    });
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
            return allPets;
        }
    }
}