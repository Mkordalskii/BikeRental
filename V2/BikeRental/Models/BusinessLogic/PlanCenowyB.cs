using BikeRental.Models.EntitiesForView;
using System.Linq;

namespace BikeRental.Models.BusinessLogic
{
    public class PlanCenowyB : DatabaseClass
    {
        #region konstruktor
        public PlanCenowyB(BikeRentalDbEntities db) : base(db)
        {
        }
        #endregion
        #region Funkcje pomocnicze
        public IQueryable<KeyAndValue> GetPlanyCenoweKeyAndValueItems()
        {
            return db.PlanCenowy
                .Where(plan => plan.CzyAktywny == true)
                .OrderBy(plan => plan.Nazwa)
                .Select(plan => new KeyAndValue
                {
                    Key = plan.PlanCenowyId,
                    Value = plan.Nazwa + " " + plan.Waluta
                }).ToList().AsQueryable();
        }
        #endregion
    }
}
