using System;

namespace BikeRental.Models.EntitiesForView
{
    public class AbonamentyForAllView
    {
        public int AbonamentId { get; set; }
        public string ImieKlienta { get; set; }
        public string NazwiskoKlienta { get; set; }
        public string PlanCenowyNazwa { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataKoniec { get; set; }
        public string Status { get; set; }
    }
}
