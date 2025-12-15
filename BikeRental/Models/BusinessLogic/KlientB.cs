using BikeRental.Models.EntitiesForView;
using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class KlientB : DatabaseClass
    {
        #region Konstruktor
        public KlientB(BikeRentalDbEntities db) : base(db) { }
        #endregion

        #region Funkcje pomocnicze
        public IQueryable<KeyAndValue> GetKlienciKeyAndValueItems()
        {
            return (
               from klient in db.Klient
               where klient.CzyAktywny == true
               select new KeyAndValue
               {
                   Key = klient.KlientId,
                   Value =
                       klient.Imie == null || klient.Imie == ""
                           ? klient.Nazwisko
                           : klient.Imie + " " + klient.Nazwisko
               }
        )
        .OrderBy(x => x.Value)
        .ToList()
        .AsQueryable();
        }
        #endregion
    }
}
