using System;
using Entity;
using Business;

namespace Service
{
    public class CashDonationService
    {
        private readonly CashDonationRepo _cashDonationRepo;

        public CashDonationService(CashDonationRepo cashDonationRepo)
        {
            _cashDonationRepo = cashDonationRepo;
        }

        public bool RecordDonation(CashDonation donation)
        {
            return _cashDonationRepo.RecordDonation(donation);
        }
    }
}