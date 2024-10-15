using System;
using System.Collections.Generic;

namespace Entity
{
    public class AdoptionEvent
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        public List<Pet> AvailablePets { get; set; }
    }
}