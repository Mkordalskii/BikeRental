using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
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
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "imie", "nazwisko", "data platnosci", "kwota", "waluta", "metoda platnosci", "status" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "imie", "nazwisko", "kwota", "waluta", "metoda platnosci", "status" };
        }
        public override void Sort()
        {
            if (SortField == "imie")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.KlientImie));
            if (SortField == "nazwisko")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.KlientNazwisko));
            if (SortField == "data platnosci")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.DataPlatnosci));
            if (SortField == "kwota")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.Kwota));
            if (SortField == "waluta")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.Waluta));
            if (SortField == "metoda platnosci")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.MetodaPlatnosci));
            if (SortField == "status")
                List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.Status));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "imie")
                    List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.KlientImie != null && item.KlientImie.StartsWith(FindTextBox)));
                if (FindField == "nazwisko")
                    List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.KlientNazwisko != null && item.KlientNazwisko.StartsWith(FindTextBox)));
                if (FindField == "kwota")
                    List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.Kwota != null && item.Kwota.ToString().StartsWith(FindTextBox.ToString())));
                if (FindField == "waluta")
                    List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.Waluta != null && item.Waluta.StartsWith(FindTextBox)));
                if (FindField == "metoda platnosci")
                    List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.MetodaPlatnosci != null && item.MetodaPlatnosci.StartsWith(FindTextBox)));
                if (FindField == "status")
                    List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.Status != null && item.Status.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
