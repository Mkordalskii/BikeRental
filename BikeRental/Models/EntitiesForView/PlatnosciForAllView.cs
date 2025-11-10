using System;

namespace BikeRental.Models.EntitiesForView
{
    public class PlatnosciForAllView
    {
        public int PlatnoscId { get; set; }
        public string KlientImie { get; set; }
        public string KlientNazwisko { get; set; }
        public int? WypozyczenieId { get; set; }
        public DateTime DataPlatnosci { get; set; }
        public decimal Kwota { get; set; }
        public string Waluta { get; set; }
        public string MetodaPlatnosci { get; set; }
        public string Referencja { get; set; }
        public string Status { get; set; }
    }
}
