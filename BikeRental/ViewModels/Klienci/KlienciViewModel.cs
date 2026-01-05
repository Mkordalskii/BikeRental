using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class KlienciViewModel : WszystkieViewModel<KlienciForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<KlienciForAllView>
                (
                from klient in db.Klient
                where klient.CzyAktywny == true
                select new KlienciForAllView
                {
                    KlientId = klient.KlientId,
                    Typ = klient.SlownikKlientTyp.Nazwa,
                    Imie = klient.Imie,
                    Nazwisko = klient.Nazwisko,
                    NIP = klient.NIP,
                    Email = klient.Email,
                    Telefon = klient.Telefon,
                    DataUrodzenia = klient.DataUrodzenia
                }
                );
        }
        #endregion
        #region Constructor
        public KlienciViewModel()
            : base()
        {
            base.DisplayName = "Wszyscy klienci";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "typ", "imie", "nazwisko", "data urodzenia" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "imie", "nazwisko", "NIP", "telefon", "e-mail" };
        }
        public override void Sort()
        {
            if (SortField == "typ")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Typ));
            if (SortField == "imie")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Imie));
            if (SortField == "nazwisko")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Nazwisko));
            if (SortField == "data urodzenia")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.DataUrodzenia));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "imie")
                    List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(FindTextBox)));
                if (FindField == "nazwisko")
                    List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
                if (FindField == "NIP")
                    List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.NIP != null && item.NIP.StartsWith(FindTextBox)));
                if (FindField == "telefon")
                    List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
                if (FindField == "e-mail")
                    List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
