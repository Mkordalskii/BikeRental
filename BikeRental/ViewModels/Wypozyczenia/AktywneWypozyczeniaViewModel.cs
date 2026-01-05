using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
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
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "imie", "nazwisko", "kod floty", "start", "koniec", "stacja poczatkowa", "stacja koncowa", "odleglosc", "plan cenowy" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "imie", "nazwisko", "kod floty", "stacja poczatkowa", "stacja koncowa", "odleglosc", "plan cenowy" };
        }
        public override void Sort()
        {
            if (SortField == "imie")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.KlientImie));
            if (SortField == "nazwisko")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.KlientNazwisko));
            if (SortField == "kod floty")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.KodFloty));
            if (SortField == "start")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.StartUtc));
            if (SortField == "koniec")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.KoniecUtc));
            if (SortField == "stacja poczatkowa")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.NazwaStacjiPoczatkowej));
            if (SortField == "stacja koncowa")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.NazwaStacjiKoncowej));
            if (SortField == "odleglosc")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.OdlegloscKm));
            if (SortField == "plan cenowy")
                List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.OrderBy(item => item.PlanCenowyIdSnapshot));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "imie")
                    List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.Where(item => item.KlientImie != null && item.KlientImie.StartsWith(FindTextBox)));
                if (FindField == "nazwisko")
                    List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.Where(item => item.KlientNazwisko != null && item.KlientNazwisko.StartsWith(FindTextBox)));
                if (FindField == "kod floty")
                    List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.Where(item => item.KodFloty != null && item.KodFloty.StartsWith(FindTextBox)));
                if (FindField == "stacja poczatkowa")
                    List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.Where(item => item.NazwaStacjiPoczatkowej != null && item.NazwaStacjiPoczatkowej.StartsWith(FindTextBox)));
                if (FindField == "stacja koncowa")
                    List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.Where(item => item.NazwaStacjiKoncowej != null && item.NazwaStacjiKoncowej.StartsWith(FindTextBox)));
                if (FindField == "odleglosc")
                    List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.Where(item => item.OdlegloscKm != null && item.OdlegloscKm.ToString().StartsWith(FindTextBox.ToString())));
                if (FindField == "plan cenowy")
                    List = new ObservableCollection<AktywneWypozyczeniaForAllView>(List.Where(item => item.PlanCenowyIdSnapshot != null && item.PlanCenowyIdSnapshot.ToString().StartsWith(FindTextBox.ToString())));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
