using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class AktywneWypozyczeniaViewModel : WszystkieViewModel<AktywneWypozyczeniaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<AktywneWypozyczeniaForAllView>
                (
                from wypozyczenie in db.Wypozyczenie
                where wypozyczenie.CzyAktywny == true
                select new AktywneWypozyczeniaForAllView
                {
                    WypozyczenieId = wypozyczenie.WypozyczenieId,
                    KlientImie = wypozyczenie.Klient.Imie,
                    KlientNazwisko = wypozyczenie.Klient.Nazwisko,
                    KodFloty = wypozyczenie.Rower.KodFloty,
                    StartUtc = wypozyczenie.StartUtc,
                    KoniecUtc = wypozyczenie.KoniecUtc,
                    NazwaStacjiPoczatkowej = wypozyczenie.Stacja1.Nazwa,
                    NazwaStacjiKoncowej = wypozyczenie.Stacja.Nazwa,
                    StartSzerGeo = wypozyczenie.StartSzerGeo,
                    StartDlugGeo = wypozyczenie.StartDlugGeo,
                    KoniecSzerGeo = wypozyczenie.KoniecSzerGeo,
                    KoniecDlugGeo = wypozyczenie.KoniecDlugGeo,
                    OdlegloscKm = wypozyczenie.OdlegloscKm,
                    PlanCenowyIdSnapshot = wypozyczenie.PlanCenowyIdSnapshot
                }
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
