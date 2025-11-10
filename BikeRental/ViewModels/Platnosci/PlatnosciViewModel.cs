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
                      KlientImie = platnosc.Klient.Imie,
                      KlientNazwisko = platnosc.Klient.Nazwisko,
                      WypozyczenieId = platnosc.WypozyczenieId,
                      DataPlatnosci = platnosc.DataPlatnosci,
                      Kwota = platnosc.Kwota,
                      Waluta = platnosc.Waluta,
                      MetodaPlatnosci =
                        platnosc.Metoda == 0 ? "karta" :
                        platnosc.Metoda == 1 ? "blik" :
                        platnosc.Metoda == 2 ? "gotowka" :
                        platnosc.Metoda == 3 ? "przelew" : "nieznana",
                      Referencja = platnosc.Referencja,
                      Status =
                        platnosc.Status == 0 ? "autoryzacja" :
                        platnosc.Status == 1 ? "zaksiegowana" :
                        platnosc.Status == 2 ? "zwrot" :
                        platnosc.Status == 3 ? "odrzucona" : "blad"
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
