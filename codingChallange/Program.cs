using System;
using Entity;
using Business;
using Service;
using Exceptions;


namespace CodingChallange
{
    class Program
    {
        static void Main(string[] args)
        {
            var cashDonationRepo = new CashDonationRepo();
            var cashDonationService = new CashDonationService(cashDonationRepo);

            var itemDonationRepo = new ItemDonationRepo();
            var itemDonationService = new ItemDonationService(itemDonationRepo);

            var petShelterRepo = new PetShelterRepo();
            var petShelterService = new PetShelterService(petShelterRepo);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Donation Management System");
                Console.WriteLine("1. Record Cash Donation");
                Console.WriteLine("2. Record Item Donation");
                Console.WriteLine("4. Pet Shelter");
                Console.WriteLine("3. Exit");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RecordCashDonation(cashDonationService);
                        break;
                    case "2":
                        RecordItemDonation(itemDonationService);
                        break;
                    case "4":
                        PetShelterMenu(petShelterService);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void RecordCashDonation(CashDonationService cashDonationService)
        {
            Console.Clear();
            Console.WriteLine("Record Cash Donation");

            Console.Write("Enter donor name: ");
            var donorName = Console.ReadLine();

            Console.Write("Enter donation amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount))
            {
                Console.WriteLine("Invalid amount. Please try again.");
                return;
            }

            var donation = new CashDonation
            {
                DonorName = donorName,
                Amount = amount,
                DonationDate = DateTime.Now
            };

            bool success = cashDonationService.RecordDonation(donation);
            Console.WriteLine(success ? "Cash donation recorded successfully." : "Failed to record cash donation.");
        }

        static void RecordItemDonation(ItemDonationService itemDonationService)
        {
            Console.Clear();
            Console.WriteLine("Record Item Donation");

            Console.Write("Enter donor name: ");
            var donorName = Console.ReadLine();

            Console.Write("Enter item type: ");
            var itemType = Console.ReadLine();

            Console.Write("Enter item value: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount))
            {
                Console.WriteLine("Invalid amount. Please try again.");
                return;
            }

            var donation = new ItemDonation
            {
                DonorName = donorName,
                ItemType = itemType,
                Amount = amount,
            };

            bool success = itemDonationService.RecordDonation(donation);
            Console.WriteLine(success ? "Item donation recorded successfully." : "Failed to record item donation.");
        }

        static void PetShelterMenu(PetShelterService petShelterService)
        {
            Console.Clear();
            Console.WriteLine("Pet Shelter Management System");
            Console.WriteLine("1. Add Pet");
            Console.WriteLine("2. Remove Pet");
            Console.WriteLine("3. View Pets");
            Console.WriteLine("4. Back to Main Menu");

            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddPet(petShelterService);
                    break;
                case "2":
                    RemovePet(petShelterService);
                    break;
                case "3":
                    ListAvailablePets(petShelterService);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        static void AddPet(PetShelterService petShelterService)
        {
            Console.Clear();
            Console.WriteLine("Add a New Pet");

            Console.Write("Enter pet name: ");
            var name = Console.ReadLine();

            Console.Write("Enter pet age: ");
            var ageInput = Console.ReadLine();
            int age;
            try
            {
                age = ExceptionHandler.GetPositiveInteger(ageInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.Write("Enter pet breed: ");
            var breed = Console.ReadLine();

            var pet = new Pet(name, age, breed);

            bool success = petShelterService.AddPet(pet);
            Console.WriteLine(success ? "Pet added successfully." : "Failed to add pet.");
        }

        static void RemovePet(PetShelterService petShelterService)
        {
            Console.Clear();
            Console.WriteLine("Remove a Pet");

            Console.Write("Enter pet name: ");
            var name = Console.ReadLine();

            Console.Write("Enter pet age: ");
            var ageInput = Console.ReadLine();
            int age;
            try
            {
                age = ExceptionHandler.GetPositiveInteger(ageInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.Write("Enter pet breed: ");
            var breed = Console.ReadLine();

            var pet = new Pet(name, age, breed);

            bool success = petShelterService.RemovePet(pet);
            Console.WriteLine(success ? "Pet removed successfully." : "Failed to remove pet.");
        }

        static void ListAvailablePets(PetShelterService petShelterService)
        {
            Console.Clear();
            Console.WriteLine("Available Pets:");

            var pets = petShelterService.ListAvailablePets();
            foreach (var pet in pets)
            {
                try
                {
                    ExceptionHandler.HandleNullReferenceException(pet);
                    Console.WriteLine($"{pet.Name}, {pet.Age} years old, {pet.Breed}");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}