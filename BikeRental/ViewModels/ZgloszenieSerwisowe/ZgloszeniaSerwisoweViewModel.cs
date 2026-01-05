using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class ZgloszeniaSerwisoweViewModel : WszystkieViewModel<ZgloszenieSerwisoweForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ZgloszenieSerwisoweForAllView>
                (
                  from zgloszenie in db.ZgloszenieSerwisowe
                  where zgloszenie.CzyAktywny == true
                  select new ZgloszenieSerwisoweForAllView
                  {
                      ZgloszenieId = zgloszenie.ZgloszenieId,
                      KodFloty = zgloszenie.Rower.KodFloty,
                      NumerSeryjny = zgloszenie.Rower.NumerSeryjny,
                      NazwiskoKlienta = zgloszenie.Klient.Nazwisko,
                      DataZgloszeniaUtc = zgloszenie.DataZgloszeniaUtc,
                      Priorytet = zgloszenie.SlownikZgloszeniePriorytet.Nazwa,
                      Opis = zgloszenie.Opis,
                      Status = zgloszenie.SlownikZgloszenieStatus.Nazwa,
                      KodStacji = zgloszenie.Stacja.Kod
                  }
                );
        }
        #endregion
        #region Constructor
        public ZgloszeniaSerwisoweViewModel()
            : base()
        {
            base.DisplayName = "Zgloszenia serwisowe";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "kod floty", "nr seryjny", "zglaszajacy", "data zgloszenia", "priorytet", "status", "kod stacji" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "kod floty", "nr seryjny", "zglaszajacy", "priorytet", "status", "kod stacji" };
        }
        public override void Sort()
        {
            if (SortField == "kod floty")
                List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.OrderBy(item => item.KodFloty));
            if (SortField == "nr seryjny")
                List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.OrderBy(item => item.NumerSeryjny));
            if (SortField == "zglaszajacy")
                List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.OrderBy(item => item.NazwiskoKlienta));
            if (SortField == "data zgloszenia")
                List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.OrderBy(item => item.DataZgloszeniaUtc));
            if (SortField == "priorytet")
                List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.OrderBy(item => item.Priorytet));
            if (SortField == "status")
                List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.OrderBy(item => item.Status));
            if (SortField == "kod stacji")
                List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.OrderBy(item => item.KodStacji));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "kod floty")
                    List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.Where(item => item.KodFloty != null && item.KodFloty.StartsWith(FindTextBox)));
                if (FindField == "nr seryjny")
                    List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.Where(item => item.NumerSeryjny != null && item.NumerSeryjny.StartsWith(FindTextBox)));
                if (FindField == "zglaszajacy")
                    List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.Where(item => item.NazwiskoKlienta != null && item.NazwiskoKlienta.StartsWith(FindTextBox)));
                if (FindField == "priorytet")
                    List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.Where(item => item.Priorytet != null && item.Priorytet.StartsWith(FindTextBox)));
                if (FindField == "status")
                    List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.Where(item => item.Status != null && item.Status.StartsWith(FindTextBox)));
                if (FindField == "kod stacji")
                    List = new ObservableCollection<ZgloszenieSerwisoweForAllView>(List.Where(item => item.KodStacji != null && item.KodStacji.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
