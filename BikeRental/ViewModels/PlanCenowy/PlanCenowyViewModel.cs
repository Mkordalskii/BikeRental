using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class PlanCenowyViewModel : WszystkieViewModel<PlanCenowy>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PlanCenowy>
                (
                db.PlanCenowy.ToList()
                );
        }
        #endregion
        #region Constructor
        public PlanCenowyViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie plany cenowe";
        }
        #endregion
    }
}
