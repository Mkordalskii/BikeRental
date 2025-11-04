using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class RezerwacjeViewModel : WszystkieViewModel<Rezerwacja>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Rezerwacja>
                (
                db.Rezerwacja.ToList()
                );
        }
        #endregion
        #region Constructor
        public RezerwacjeViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie rezerwacje";
        }
        #endregion
    }
}
