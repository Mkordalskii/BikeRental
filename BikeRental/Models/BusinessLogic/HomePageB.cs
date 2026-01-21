using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class HomePageB : DatabaseClass
    {
        public HomePageB(BikeRentalDbEntities db) : base(db)
        {
        }
        #region Funkcje pomocnicze
        public int GetActiveRentalsCount()
        {
            return db.Wypozyczenie
                .Where(wypozyczenie => wypozyczenie.CzyAktywny == true)
                .Count();
        }
        public int GetAvilableBikesCount()
        {
            return db.Rower
                .Where(rower => rower.CzyAktywny == true && rower.SlownikRowerStan.Nazwa == "Dostępny")
                .Count();
        }
        public int GetReservedBikesCount()
        {
            return db.Rezerwacja
                .Where(rezerwacja => rezerwacja.CzyAktywny == true)
                .Count();
        }
        public decimal GetTotalRevenue()
        {
            return db.WypozyczenieOplata
                .Where(oplata => oplata.CzyAktywny == true)
                .Sum(oplata => oplata.Kwota);
        }
        #endregion
    }
}
