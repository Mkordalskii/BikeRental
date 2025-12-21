namespace BikeRental.Models.EntitiesForView
{
    public class WypozyczenieOplataForAllView
    {
        public int OplataId { get; set; }
        public int WypozyczenieId { get; set; }
        public string Typ { get; set; }
        public int? IloscMin { get; set; }
        public decimal? Stawka { get; set; }
        public decimal Kwota { get; set; }
    }
}
