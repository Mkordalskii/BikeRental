using System;

namespace BikeRental.Models.EntitiesForView
{
    public class ZgloszenieSerwisoweForAllView
    {
        public int ZgloszenieId { get; set; }
        public string KodFloty { get; set; }
        public string NumerSeryjny { get; set; }
        public string NazwiskoKlienta { get; set; }
        public DateTime DataZgloszeniaUtc { get; set; }
        public string Priorytet { get; set; }
        public string Opis { get; set; }
        public string Status { get; set; }
        public string KodStacji { get; set; }
    }
}
