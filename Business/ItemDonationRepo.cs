using System;
using System.Data.SqlClient;
using Entity;
using DbConnection;

namespace Business
{
    public class ItemDonationRepo : Donation
    {
        public override bool RecordDonation(Entity.Donation donation)
        {
            // Cast the generic Donation entity to ItemDonation to access ItemType
            if (donation is not ItemDonation itemDonation)
            {
                throw new ArgumentException("Invalid donation type");
            }

            using SqlConnection connection = DBConnection.GetConnection();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Insert into Donations table
                var command = new SqlCommand(
                    "INSERT INTO Donations (DonorName, Amount) OUTPUT INSERTED.Id VALUES (@DonorName, @Amount)",
                    connection,
                    transaction
                );

                command.Parameters.AddWithValue("@DonorName", itemDonation.DonorName);
                command.Parameters.AddWithValue("@Amount", itemDonation.Amount);

                int donationId = (int)command.ExecuteScalar();

                // Insert into ItemDonations table
                command = new SqlCommand(
                    "INSERT INTO ItemDonations (Id, ItemType) VALUES (@Id, @ItemType)",
                    connection,
                    transaction
                );

                command.Parameters.AddWithValue("@Id", donationId);
                command.Parameters.AddWithValue("@ItemType", itemDonation.ItemType);

                command.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}