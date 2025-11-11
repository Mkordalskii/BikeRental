using System;

namespace BikeRental.Models.EntitiesForView
{
    public class RezerwacjeForAllView
    {
        public int RezerwacjaId { get; set; }
        public string KlientImie { get; set; }
        public string KlientNazwisko { get; set; }
        public string KodFloty { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }

    }
}
