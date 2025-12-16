using System;

namespace BikeRental.Models.EntitiesForView
{
    public class RowerDoSerwisuForAllView
    {
        public int RowerId { get; set; }
        public string KodFloty { get; set; }
        public string NumerSeryjny { get; set; }
        public string Model { get; set; }
        public string Stan { get; set; }
        public string Stacja { get; set; }
        public decimal? PrzebiegKm { get; set; }
        public DateTime? DataPrzegladu { get; set; }
        public string Powod { get; set; }
    }
}
