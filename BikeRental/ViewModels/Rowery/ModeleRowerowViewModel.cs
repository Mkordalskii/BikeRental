using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class ModeleRowerowViewModel : WszystkieViewModel<RowerModel>
    {

        #region Lista

        public override void Load()
        {
            List = new ObservableCollection<RowerModel>
                (
                db.RowerModel.ToList()
                );
        }

        #endregion Lista
        #region Constructor
        public ModeleRowerowViewModel() : base()
        {
            DisplayName = "Modele rowerow";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "producent", "nazwa", "typ", "e-bike", "masa" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "producent", "nazwa", "typ", "masa" };
        }
        public override void Sort()
        {
            if (SortField == "producent")
                List = new ObservableCollection<RowerModel>(List.OrderBy(item => item.Producent));
            if (SortField == "nazwa")
                List = new ObservableCollection<RowerModel>(List.OrderBy(item => item.Nazwa));
            if (SortField == "typ")
                List = new ObservableCollection<RowerModel>(List.OrderBy(item => item.Typ));
            if (SortField == "e-bike")
                List = new ObservableCollection<RowerModel>(List.OrderBy(item => item.E_Bike));
            if (SortField == "masa")
                List = new ObservableCollection<RowerModel>(List.OrderBy(item => item.MasaKg));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "producent")
                    List = new ObservableCollection<RowerModel>(List.Where(item => item.Producent != null && item.Producent.StartsWith(FindTextBox)));
                if (FindField == "nazwa")
                    List = new ObservableCollection<RowerModel>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
                if (FindField == "typ")
                    List = new ObservableCollection<RowerModel>(List.Where(item => item.Typ != null && item.Typ.StartsWith(FindTextBox)));
                if (FindField == "masa")
                    List = new ObservableCollection<RowerModel>(List.Where(item => item.MasaKg != null && item.MasaKg.ToString().StartsWith(FindTextBox.ToString())));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}