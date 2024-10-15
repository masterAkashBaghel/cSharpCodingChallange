
namespace Business
{
    public abstract class Donation
    {
        // This abstract method will handle the donation process in derived classes
        public abstract bool RecordDonation(Entity.Donation donation);
    }
}
