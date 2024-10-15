
using Entity;

namespace Business
{
    public interface IPetShelter
    {
        bool AddPet(Pet pet);
        bool RemovePet(Pet pet);
        List<Pet> ListAvailablePets();
    }
}