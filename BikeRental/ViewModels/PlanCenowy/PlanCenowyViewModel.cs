using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class PlanCenowyViewModel : WszystkieViewModel<PlanCenowy>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PlanCenowy>
                (
                db.PlanCenowy.ToList()
                );
        }
        #endregion
        #region Constructor
        public PlanCenowyViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie plany cenowe";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "nazwa", "waluta", "od", "do" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "nazwa", "waluta" };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
                List = new ObservableCollection<PlanCenowy>(List.OrderBy(item => item.Nazwa));
            if (SortField == "waluta")
                List = new ObservableCollection<PlanCenowy>(List.OrderBy(item => item.Waluta));
            if (SortField == "od")
                List = new ObservableCollection<PlanCenowy>(List.OrderBy(item => item.AktywnaOd));
            if (SortField == "do")
                List = new ObservableCollection<PlanCenowy>(List.OrderBy(item => item.AktywnaDo));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "nazwa")
                    List = new ObservableCollection<PlanCenowy>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
                if (FindField == "waluta")
                    List = new ObservableCollection<PlanCenowy>(List.Where(item => item.Waluta != null && item.Waluta.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
