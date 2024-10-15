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
            var command = new SqlCommand("INSERT INTO CashDonations (DonorName, Amount, DonationDate) VALUES (@DonorName, @Amount, @DonationDate)", connection);

            // Use cash donation entity properties for the insert
            command.Parameters.AddWithValue("@DonorName", cashDonation.DonorName);
            command.Parameters.AddWithValue("@Amount", cashDonation.Amount);
            command.Parameters.AddWithValue("@DonationDate", cashDonation.DonationDate);


            return command.ExecuteNonQuery() > 0;
        }
    }
}
