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
            var command = new SqlCommand("INSERT INTO ItemDonations (DonorName, Amount, ItemType) VALUES (@DonorName, @Amount, @ItemType)", connection);

            // Use item donation entity properties for the insert
            command.Parameters.AddWithValue("@DonorName", itemDonation.DonorName);
            command.Parameters.AddWithValue("@Amount", itemDonation.Amount);
            command.Parameters.AddWithValue("@ItemType", itemDonation.ItemType);


            return command.ExecuteNonQuery() > 0;
        }
    }
}
