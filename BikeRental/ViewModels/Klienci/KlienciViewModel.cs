using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class KlienciViewModel : WszystkieViewModel<Klient>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Klient>
                (
                db.Klient.ToList()// z bazy danych, pobieram wszystkich klientow i zamieniam na liste
                );
        }
        #endregion
        #region Constructor
        public KlienciViewModel()
            : base()
        {
            base.DisplayName = "Wszyscy klienci";
        }
        #endregion
    }
}
