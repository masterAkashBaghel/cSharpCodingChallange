using System.Collections.Generic;

namespace Entity
{
    public class PetShelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> AvailablePets { get; set; }
    }
}