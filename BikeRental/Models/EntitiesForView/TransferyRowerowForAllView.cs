using System;

namespace BikeRental.Models.EntitiesForView
{
    public class TransferyRowerowForAllView
    {
        public int TransferId { get; set; }
        public string KodFloty { get; set; }
        public string NumerSeryjny { get; set; }
        public string KodStacjiZrodlowej { get; set; }
        public string KodStacjiDocelowej { get; set; }
        public DateTime DataStartUtc { get; set; }
        public DateTime? DataKoniecUtc { get; set; }
        public string Status { get; set; }
        public string Uwagi { get; set; }
    }
}
