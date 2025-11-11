using System;

namespace BikeRental.Models.EntitiesForView
{
    public class AktywneWypozyczeniaForAllView
    {
        public int WypozyczenieId { get; set; }
        public string KlientImie { get; set; }
        public string KlientNazwisko { get; set; }
        public string KodFloty { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime KoniecUtc { get; set; }
        public string NazwaStacjiPoczatkowej { get; set; }
        public string NazwaStacjiKoncowej { get; set; }
        public decimal? StartSzerGeo { get; set; }
        public decimal? StartDlugGeo { get; set; }
        public decimal? KoniecSzerGeo { get; set; }
        public decimal? KoniecDlugGeo { get; set; }
        public decimal? OdlegloscKm { get; set; }
        public string PlanCenowy { get; set; }
    }
}
