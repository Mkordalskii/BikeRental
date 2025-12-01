using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class PlatnosciViewModel : WszystkieViewModel<PlatnosciForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PlatnosciForAllView>
                (
                  from platnosc in db.Platnosc
                  where platnosc.CzyAktywny == true
                  select new PlatnosciForAllView
                  {
                      PlatnoscId = platnosc.PlatnoscId,
                      KlientImie = platnosc.Klient.Imie,
                      KlientNazwisko = platnosc.Klient.Nazwisko,
                      WypozyczenieId = platnosc.WypozyczenieId,
                      DataPlatnosci = platnosc.DataPlatnosci,
                      Kwota = platnosc.Kwota,
                      Waluta = platnosc.Waluta,
                      MetodaPlatnosci = platnosc.SlownikPlatnoscMetoda.Nazwa,
                      Referencja = platnosc.Referencja,
                      Status = platnosc.SlownikPlatnoscStatus.Nazwa
                  }
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
