using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class PlatnosciViewModel : WszystkieViewModel<Platnosc>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Platnosc>
                (
                db.Platnosc.ToList()
                );
        }
        #endregion
        #region Constructor
        public PlatnosciViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie platnosci";
        }
        #endregion
    }
}
