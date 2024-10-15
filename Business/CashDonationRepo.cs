using System;
using System.Data.SqlClient;
using Entity;
using DbConnection;

namespace Business
{
    public class CashDonationRepo : Donation
    {
        public override bool RecordDonation(Entity.Donation donation)
        {
            // Cast the generic Donation entity to CashDonation to access DonationDate
            if (donation is not CashDonation cashDonation)
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

                command.Parameters.AddWithValue("@DonorName", cashDonation.DonorName);
                command.Parameters.AddWithValue("@Amount", cashDonation.Amount);

                int donationId = (int)command.ExecuteScalar();

                // Insert into CashDonations table
                command = new SqlCommand(
                    "INSERT INTO CashDonations (Id, DonationDate) VALUES (@Id, @DonationDate)",
                    connection,
                    transaction
                );

                command.Parameters.AddWithValue("@Id", donationId);
                command.Parameters.AddWithValue("@DonationDate", cashDonation.DonationDate);

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