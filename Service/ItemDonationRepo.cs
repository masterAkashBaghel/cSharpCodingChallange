using System;
using Entity;
using Business;

namespace Service
{
    public class ItemDonationService
    {
        private readonly ItemDonationRepo _itemDonationRepo;

        public ItemDonationService(ItemDonationRepo itemDonationRepo)
        {
            _itemDonationRepo = itemDonationRepo;
        }

        public bool RecordDonation(ItemDonation donation)
        {
            return _itemDonationRepo.RecordDonation(donation);
        }
    }
}
