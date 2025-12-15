using BikeRental.Models.EntitiesForView;
using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class RowerB : DatabaseClass
    {
        #region Konstruktor
        public RowerB(BikeRentalDbEntities db) : base(db) { }
        #endregion

        #region Funkcje pomocnicze
        public IQueryable<KeyAndValue> GetRoweryKeyAndValueItems()
        {
            return (
                from rower in db.Rower
                where rower.CzyAktywny == true
                orderby rower.KodFloty
                select new KeyAndValue
                {
                    Key = rower.RowerId,
                    Value = rower.KodFloty
                }
            ).ToList().AsQueryable();
        }
        #endregion
    }
}
