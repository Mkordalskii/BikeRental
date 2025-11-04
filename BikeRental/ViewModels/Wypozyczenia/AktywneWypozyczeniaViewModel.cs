using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class AktywneWypozyczeniaViewModel : WszystkieViewModel<Wypozyczenie>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Wypozyczenie>
                (
                db.Wypozyczenie.ToList()
                );
        }
        #endregion
        #region Constructor
        public AktywneWypozyczeniaViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie aktywne wypozyczenia";
        }
        #endregion
    }
}
