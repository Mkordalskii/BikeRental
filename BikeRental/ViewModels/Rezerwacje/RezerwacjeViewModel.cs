using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class RezerwacjeViewModel : WszystkieViewModel<RezerwacjeForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<RezerwacjeForAllView>
                (
                  from rezerwacja in db.Rezerwacja
                  where rezerwacja.CzyAktywny == true
                  select new RezerwacjeForAllView
                  {
                      RezerwacjaId = rezerwacja.RezerwacjaId,
                      KlientImie = rezerwacja.Klient.Imie,
                      KlientNazwisko = rezerwacja.Klient.Nazwisko,
                      KodFloty = rezerwacja.Rower.KodFloty,
                      DataOd = rezerwacja.DataOdUtc,
                      DataDo = rezerwacja.DataDoUtc
                  }
                );
        }
        #endregion
        #region Constructor
        public RezerwacjeViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie rezerwacje";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "imie", "nazwisko", "kod", "data od", "data do" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "imie", "nazwisko", "kod" };
        }
        public override void Sort()
        {
            if (SortField == "imie")
                List = new ObservableCollection<RezerwacjeForAllView>(List.OrderBy(item => item.KlientImie));
            if (SortField == "nazwisko")
                List = new ObservableCollection<RezerwacjeForAllView>(List.OrderBy(item => item.KlientNazwisko));
            if (SortField == "kod")
                List = new ObservableCollection<RezerwacjeForAllView>(List.OrderBy(item => item.KodFloty));
            if (SortField == "data od")
                List = new ObservableCollection<RezerwacjeForAllView>(List.OrderBy(item => item.DataOd));
            if (SortField == "data do")
                List = new ObservableCollection<RezerwacjeForAllView>(List.OrderBy(item => item.DataDo));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "imie")
                    List = new ObservableCollection<RezerwacjeForAllView>(List.Where(item => item.KlientImie != null && item.KlientImie.StartsWith(FindTextBox)));
                if (FindField == "nazwisko")
                    List = new ObservableCollection<RezerwacjeForAllView>(List.Where(item => item.KlientNazwisko != null && item.KlientNazwisko.StartsWith(FindTextBox)));
                if (FindField == "kod")
                    List = new ObservableCollection<RezerwacjeForAllView>(List.Where(item => item.KodFloty != null && item.KodFloty.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
