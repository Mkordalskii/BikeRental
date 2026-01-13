using System;

namespace BikeRental.Models.EntitiesForView
{
    public class RaportPodsumowanieDto
    {
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public int? KlientId { get; set; }
        public int? RowerId { get; set; }
        public int? StacjaStartId { get; set; }
        public int? StacjaKoniecId { get; set; }
        public int LiczbaWypozyczen { get; set; }
        public int LacznyCzasMin { get; set; }
        public decimal LacznyDystansKm { get; set; }
        public decimal Przychod { get; set; }
    }
}
