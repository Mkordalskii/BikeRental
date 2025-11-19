using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;

namespace BikeRental.ViewModels
{
    public class PlanyCenoweViewModel : WszystkieViewModel<PlanCenowy>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PlanCenowy>
                (
                db.PlanCenowy.ToList()// z bazy danych, pobieram wszystkich klientow i zamieniam na liste
                );
        }
        #endregion
        #region Constructor
        public PlanyCenoweViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie plany cenowe";
        }
        #endregion
    }
}
