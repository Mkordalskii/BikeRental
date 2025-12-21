namespace BikeRental.Models.EntitiesForView
{
    public class PlanCenowyStawkaForAllView
    {
        public int StawkaId { get; set; }
        public string PlanCenowyNazwa { get; set; }
        public string Typ { get; set; }
        public int? OdMinuty { get; set; }
        public int? DoMinuty { get; set; }
        public decimal? CenaZaMin { get; set; }
        public decimal? OplataStartowa { get; set; }
        public decimal? LimitDarmowychMin { get; set; }
        public decimal? DoplataPoLimicie { get; set; }
    }
}
