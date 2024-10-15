using System.Collections.Generic;
using Entity;
using Business;

namespace Service
{
    public class PetShelterService
    {
        private readonly PetShelterRepo _petShelterRepo;

        public PetShelterService(PetShelterRepo petShelterRepo)
        {
            _petShelterRepo = petShelterRepo;
        }

        public bool AddPet(Pet pet)
        {
            return _petShelterRepo.AddPet(pet);
        }

        public bool RemovePet(Pet pet)
        {
            return _petShelterRepo.RemovePet(pet);
        }

        public List<Pet> ListAvailablePets()
        {
            return _petShelterRepo.ListAvailablePets();
        }
    }
}