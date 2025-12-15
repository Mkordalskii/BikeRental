using BikeRental.Models.EntitiesForView;
using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class StacjaB : DatabaseClass
    {
        #region Konstruktor
        public StacjaB(BikeRentalDbEntities db) : base(db) { }
        #endregion

        #region Funkcje pomocnicze
        public IQueryable<KeyAndValue> GetStacjeKeyAndValueItems()
        {
            return (
                from stacja in db.Stacja
                where stacja.CzyAktywny == true
                orderby stacja.Nazwa
                select new KeyAndValue
                {
                    Key = stacja.StacjaId,
                    Value = stacja.Nazwa
                }
            ).ToList().AsQueryable();
        }
        #endregion
    }
}
