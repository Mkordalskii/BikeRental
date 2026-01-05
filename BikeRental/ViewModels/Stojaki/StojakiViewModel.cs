using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    internal class StojakiViewModel : WszystkieViewModel<StojakiForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<StojakiForAllView>
                (
                from stojak in db.Stojak
                where stojak.CzyAktywny == true
                select new StojakiForAllView
                {
                    StojakId = stojak.StojakId,
                    NazwaStacji = stojak.Stacja.Nazwa,
                    NumerMiejsca = stojak.NumerMiejsca,
                    CzySprawny =
                        stojak.Sprawny == true ? "Tak" :
                        stojak.Sprawny == false ? "Nie" : "Nieznany"
                }
                );
        }
        #endregion Lista
        #region Constructor
        public StojakiViewModel() : base()
        {
            DisplayName = "Wszystkie stojaki";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "stacja", "nr miejsca", "sprawnosc" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "stacja", "nr miejsca" };
        }
        public override void Sort()
        {
            if (SortField == "stacja")
                List = new ObservableCollection<StojakiForAllView>(List.OrderBy(item => item.NazwaStacji));
            if (SortField == "nr miejsca")
                List = new ObservableCollection<StojakiForAllView>(List.OrderBy(item => item.NumerMiejsca));
            if (SortField == "sprawnosc")
                List = new ObservableCollection<StojakiForAllView>(List.OrderBy(item => item.CzySprawny));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "stacja")
                    List = new ObservableCollection<StojakiForAllView>(List.Where(item => item.NazwaStacji != null && item.NazwaStacji.StartsWith(FindTextBox)));
                if (FindField == "nr miejsca")
                    List = new ObservableCollection<StojakiForAllView>(List.Where(item => item.NumerMiejsca != null && item.NumerMiejsca.ToString().StartsWith(FindTextBox.ToString())));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
