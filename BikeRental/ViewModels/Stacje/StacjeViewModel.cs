using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class StacjeViewModel : WszystkieViewModel<Stacja>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Stacja>
                (
                db.Stacja.ToList()
                );
        }
        #endregion
        #region Constructor
        public StacjeViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie stacje";
        }
        #endregion
    }
}
