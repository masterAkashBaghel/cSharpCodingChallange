
using System.Data.SqlClient;
using Entity;
using DbConnection;

namespace Business
{
    public class PetShelterRepo : IPetShelter
    {
        public bool AddPet(Pet pet)
        {
            using SqlConnection connection = DBConnection.GetConnection();
            var command = new SqlCommand("INSERT INTO Pets (Name, Age, Breed) VALUES (@Name, @Age, @Breed)", connection);
            command.Parameters.AddWithValue("@Name", pet.Name);
            command.Parameters.AddWithValue("@Age", pet.Age);
            command.Parameters.AddWithValue("@Breed", pet.Breed);

            return command.ExecuteNonQuery() > 0;
        }

        public bool RemovePet(Pet pet)
        {
            using SqlConnection connection = DBConnection.GetConnection();
            var command = new SqlCommand("DELETE FROM Pets WHERE Name = @Name AND Age = @Age AND Breed = @Breed", connection);
            command.Parameters.AddWithValue("@Name", pet.Name);
            command.Parameters.AddWithValue("@Age", pet.Age);
            command.Parameters.AddWithValue("@Breed", pet.Breed);

            return command.ExecuteNonQuery() > 0;
        }

        public List<Pet> ListAvailablePets()
        {
            var pets = new List<Pet>();

            using SqlConnection connection = DBConnection.GetConnection();
            var command = new SqlCommand("SELECT Name, Age, Breed FROM Pets", connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var pet = new Pet(
                    reader["Name"].ToString(),
                    Convert.ToInt32(reader["Age"]),
                    reader["Breed"].ToString()
                );
                pets.Add(pet);
            }

            return pets;
        }
    }
}