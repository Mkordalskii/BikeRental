using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class WypozyczenieOplataViewModel : WszystkieViewModel<WypozyczenieOplataForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<WypozyczenieOplataForAllView>
                (
                from oplata in db.WypozyczenieOplata
                where oplata.CzyAktywny == true
                select new WypozyczenieOplataForAllView
                {
                    OplataId = oplata.OplataId,
                    WypozyczenieId = oplata.WypozyczenieId,
                    Typ = oplata.SlownikWypozyczenieOplataTyp.Nazwa,
                    IloscMin = oplata.IloscMin,
                    Stawka = oplata.Stawka,
                    Kwota = oplata.Kwota
                }
                );
        }
        #endregion
        #region Constructor
        public WypozyczenieOplataViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie oplaty za wypozyczenie";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "wypozyczenie", "typ", "minuty", "stawka", "kwota" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "wypozyczenie", "typ", "minuty", "stawka", "kwota" };
        }
        public override void Sort()
        {
            if (SortField == "wypozyczenie")
                List = new ObservableCollection<WypozyczenieOplataForAllView>(List.OrderBy(item => item.WypozyczenieId));
            if (SortField == "typ")
                List = new ObservableCollection<WypozyczenieOplataForAllView>(List.OrderBy(item => item.Typ));
            if (SortField == "minuty")
                List = new ObservableCollection<WypozyczenieOplataForAllView>(List.OrderBy(item => item.IloscMin));
            if (SortField == "stawka")
                List = new ObservableCollection<WypozyczenieOplataForAllView>(List.OrderBy(item => item.Stawka));
            if (SortField == "kwota")
                List = new ObservableCollection<WypozyczenieOplataForAllView>(List.OrderBy(item => item.Kwota));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "wypozyczenie")
                    List = new ObservableCollection<WypozyczenieOplataForAllView>(List.Where(item => item.WypozyczenieId != null && item.WypozyczenieId.ToString().StartsWith(FindTextBox.ToString())));
                if (FindField == "typ")
                    List = new ObservableCollection<WypozyczenieOplataForAllView>(List.Where(item => item.Typ != null && item.Typ.StartsWith(FindTextBox)));
                if (FindField == "minuty")
                    List = new ObservableCollection<WypozyczenieOplataForAllView>(List.Where(item => item.IloscMin != null && item.IloscMin.ToString().StartsWith(FindTextBox.ToString())));
                if (FindField == "stawka")
                    List = new ObservableCollection<WypozyczenieOplataForAllView>(List.Where(item => item.Stawka != null && item.Stawka.ToString().StartsWith(FindTextBox.ToString())));
                if (FindField == "kwota")
                    List = new ObservableCollection<WypozyczenieOplataForAllView>(List.Where(item => item.Kwota != null && item.Kwota.ToString().StartsWith(FindTextBox.ToString())));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
