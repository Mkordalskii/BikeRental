using System;

namespace BikeRental.Models.EntitiesForView
{
    public class RoweryForAllView
    {
        public int RowerId { get; set; }
        public string RowerProducent { get; set; }
        public string RowerNazwaModelu { get; set; }
        public string NumerSeryjny { get; set; }
        public string KodFloty { get; set; }
        public string Stan { get; set; }
        public string OstatniaStacjaNazwa { get; set; }
        public int? OstatniStojakId { get; set; }
        public decimal? OstatniaSzerGeo { get; set; }
        public decimal? OstatniaDlugGeo { get; set; }
        public decimal? PrzebiegKm { get; set; }
        public byte? PoziomBateriiProc { get; set; }
        public DateTime? DataPrzegladu { get; set; }
    }
}
