using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class RoweryViewModel : WszystkieViewModel<Rower>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Rower>
                (
                db.Rower.ToList()
                );
        }
        #endregion
        #region Constructor
        public RoweryViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie rowery";
        }
        #endregion
    }
}
