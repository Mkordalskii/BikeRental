using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
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
                      Status = abonament.SlownikAbonamentStatus.Nazwa
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
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "imie", "nazwisko", "plan cenowy", "data start", "data koniec", "status" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "imie", "nazwisko", "plan cenowy", "status" };
        }
        public override void Sort()
        {
            if (SortField == "imie")
                List = new ObservableCollection<AbonamentyForAllView>(List.OrderBy(item => item.ImieKlienta));
            if (SortField == "nazwisko")
                List = new ObservableCollection<AbonamentyForAllView>(List.OrderBy(item => item.NazwiskoKlienta));
            if (SortField == "plan cenowy")
                List = new ObservableCollection<AbonamentyForAllView>(List.OrderBy(item => item.PlanCenowyNazwa));
            if (SortField == "data start")
                List = new ObservableCollection<AbonamentyForAllView>(List.OrderBy(item => item.DataStart));
            if (SortField == "data koniec")
                List = new ObservableCollection<AbonamentyForAllView>(List.OrderBy(item => item.DataKoniec));
            if (SortField == "status")
                List = new ObservableCollection<AbonamentyForAllView>(List.OrderBy(item => item.Status));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "imie")
                    List = new ObservableCollection<AbonamentyForAllView>(List.Where(item => item.ImieKlienta != null && item.ImieKlienta.StartsWith(FindTextBox)));
                if (FindField == "nazwisko")
                    List = new ObservableCollection<AbonamentyForAllView>(List.Where(item => item.NazwiskoKlienta != null && item.NazwiskoKlienta.StartsWith(FindTextBox)));
                if (FindField == "plan cenowy")
                    List = new ObservableCollection<AbonamentyForAllView>(List.Where(item => item.PlanCenowyNazwa != null && item.PlanCenowyNazwa.StartsWith(FindTextBox)));
                if (FindField == "status")
                    List = new ObservableCollection<AbonamentyForAllView>(List.Where(item => item.Status != null && item.Status.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
