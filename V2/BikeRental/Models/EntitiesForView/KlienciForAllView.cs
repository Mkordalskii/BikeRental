using System;

namespace BikeRental.Models.EntitiesForView
{
    public class KlienciForAllView
    {
        public int KlientId { get; set; }
        public string Typ { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NIP { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime? DataUrodzenia { get; set; }
    }
}
