using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class KlienciViewModel : WszystkieViewModel<KlienciForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<KlienciForAllView>
                (
                from klient in db.Klient
                where klient.CzyAktywny == true
                select new KlienciForAllView
                {
                    KlientId = klient.KlientId,
                    Typ = klient.SlownikKlientTyp.Nazwa,
                    Imie = klient.Imie,
                    Nazwisko = klient.Nazwisko,
                    NIP = klient.NIP,
                    Email = klient.Email,
                    Telefon = klient.Telefon,
                    DataUrodzenia = klient.DataUrodzenia
                }
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
