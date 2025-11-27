using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class AbonamentyViewModel : WszystkieViewModel<AbonamentyForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<AbonamentyForAllView>
                (
                  from abonament in db.Abonament
                  where abonament.CzyAktywny == true
                  select new AbonamentyForAllView
                  {
                      AbonamentId = abonament.AbonamentId,
                      ImieKlienta = abonament.Klient.Imie,
                      NazwiskoKlienta = abonament.Klient.Nazwisko,
                      PlanCenowyNazwa = abonament.PlanCenowy.Nazwa,
                      DataStart = abonament.DataStart,
                      DataKoniec = abonament.DataKoniec,
                      Status =
                        abonament.Status == 0 ? "aktywny" :
                        abonament.Status == 1 ? "nieaktywny" :
                        abonament.Status == 2 ? "zawieszony" : "brak"
                  }
                );
        }
        #endregion
        #region Constructor
        public AbonamentyViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie abonamenty";
        }
        #endregion
    }
}
