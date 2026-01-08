using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class RoweryViewModel : WszystkieViewModel<RoweryForAllView>
    {
        #region Lista

        public override void Load()
        {
            List = new ObservableCollection<RoweryForAllView>
                (
                   from rower in db.Rower
                   where rower.CzyAktywny == true
                   select new RoweryForAllView
                   {
                       RowerId = rower.RowerId,
                       RowerProducent = rower.RowerModel.Producent,
                       RowerNazwaModelu = rower.RowerModel.Nazwa,
                       NumerSeryjny = rower.NumerSeryjny,
                       KodFloty = rower.KodFloty,
                       Stan = rower.SlownikRowerStan.Nazwa,
                       OstatniaStacjaNazwa = rower.Stacja.Nazwa,
                       OstatniStojakId = rower.OstatniStojakId,
                       OstatniaSzerGeo = rower.OstatniaSzerGeo,
                       OstatniaDlugGeo = rower.OstatniaDlugGeo,
                       PrzebiegKm = rower.PrzebiegKm,
                       PoziomBateriiProc = rower.PoziomBateriiProc,
                       DataPrzegladu = rower.DataPrzegladu
                   }
                );
        }

        #endregion Lista
        #region Properties
        private RoweryForAllView _WybranyRower;
        public RoweryForAllView WybranyRower
        {
            get
            {
                return _WybranyRower;
            }
            set //jak ustawiamy _WybranyRower to zamykane jest okno
            {
                if (_WybranyRower != value)
                {
                    _WybranyRower = value;
                    Messenger.Default.Send(_WybranyRower);
                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Constructor

        public RoweryViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie rowery";
        }

        #endregion Constructor
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "producent", "model", "kod", "stan", "stacja", "przebieg", "bateria", "data przegladu" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "producent", "model", "nr seryjny", "kod", "stan", "stacja", "przebieg" };
        }
        public override void Sort()
        {
            if (SortField == "producent")
                List = new ObservableCollection<RoweryForAllView>(List.OrderBy(item => item.RowerProducent));
            if (SortField == "model")
                List = new ObservableCollection<RoweryForAllView>(List.OrderBy(item => item.RowerNazwaModelu));
            if (SortField == "kod")
                List = new ObservableCollection<RoweryForAllView>(List.OrderBy(item => item.KodFloty));
            if (SortField == "stan")
                List = new ObservableCollection<RoweryForAllView>(List.OrderBy(item => item.Stan));
            if (SortField == "stacja")
                List = new ObservableCollection<RoweryForAllView>(List.OrderBy(item => item.OstatniaStacjaNazwa));
            if (SortField == "przebieg")
                List = new ObservableCollection<RoweryForAllView>(List.OrderBy(item => item.PrzebiegKm));
            if (SortField == "bateria")
                List = new ObservableCollection<RoweryForAllView>(List.OrderBy(item => item.PoziomBateriiProc));
            if (SortField == "data przegladu")
                List = new ObservableCollection<RoweryForAllView>(List.OrderBy(item => item.DataPrzegladu));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "producent")
                    List = new ObservableCollection<RoweryForAllView>(List.Where(item => item.RowerProducent != null && item.RowerProducent.StartsWith(FindTextBox)));
                if (FindField == "model")
                    List = new ObservableCollection<RoweryForAllView>(List.Where(item => item.RowerNazwaModelu != null && item.RowerNazwaModelu.StartsWith(FindTextBox)));
                if (FindField == "nr seryjny")
                    List = new ObservableCollection<RoweryForAllView>(List.Where(item => item.NumerSeryjny != null && item.NumerSeryjny.StartsWith(FindTextBox)));
                if (FindField == "kod")
                    List = new ObservableCollection<RoweryForAllView>(List.Where(item => item.KodFloty != null && item.KodFloty.StartsWith(FindTextBox)));
                if (FindField == "stan")
                    List = new ObservableCollection<RoweryForAllView>(List.Where(item => item.Stan != null && item.Stan.StartsWith(FindTextBox)));
                if (FindField == "stacja")
                    List = new ObservableCollection<RoweryForAllView>(List.Where(item => item.OstatniaStacjaNazwa != null && item.OstatniaStacjaNazwa.StartsWith(FindTextBox)));
                if (FindField == "przebieg")
                    List = new ObservableCollection<RoweryForAllView>(List.Where(item => item.PrzebiegKm != null && item.PrzebiegKm.ToString().StartsWith(FindTextBox.ToString())));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}