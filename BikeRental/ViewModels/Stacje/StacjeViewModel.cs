using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class StacjeViewModel : WszystkieViewModel<Stacja>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Stacja>
                (
                db.Stacja.ToList()
                );
        }
        #endregion
        #region Constructor
        public StacjeViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie stacje";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "kod", "nazwa" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "kod", "nazwa" };
        }
        public override void Sort()
        {
            if (SortField == "kod")
                List = new ObservableCollection<Stacja>(List.OrderBy(item => item.Kod));
            if (SortField == "nazwa")
                List = new ObservableCollection<Stacja>(List.OrderBy(item => item.Nazwa));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "kod")
                    List = new ObservableCollection<Stacja>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
                if (FindField == "nazwa")
                    List = new ObservableCollection<Stacja>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
