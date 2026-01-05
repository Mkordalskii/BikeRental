using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class TransferyRowerowViewModel : WszystkieViewModel<TransferyRowerowForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<TransferyRowerowForAllView>
                (
                  from transfer in db.TransferRoweru
                  where transfer.CzyAktywny == true
                  select new TransferyRowerowForAllView
                  {
                      TransferId = transfer.TransferId,
                      KodFloty = transfer.Rower.KodFloty,
                      NumerSeryjny = transfer.Rower.NumerSeryjny,
                      KodStacjiZrodlowej = transfer.Stacja.Kod,
                      KodStacjiDocelowej = transfer.Stacja.Kod,
                      DataStartUtc = transfer.DataStartUtc,
                      DataKoniecUtc = transfer.DataKoniecUtc,
                      Status = transfer.SlownikTransferStatus.Nazwa,
                      Uwagi = transfer.Uwagi
                  }
                );
        }
        #endregion
        #region Constructor
        public TransferyRowerowViewModel()
            : base()
        {
            base.DisplayName = "Transfery rowerow";
        }
        #endregion
        #region Sortowanie i filtrowanie
        //decydujemy po czym mozna sortowac
        public override List<string> getComboBoxSortList()
        {
            return new List<string> { "kod floty", "nr seryjny", "kod stacji zrodlowej", "kod stacji docelowej", "data start", "data koniec", "status" };
        }
        public override List<string> getComboBoxFindList()
        {
            return new List<string> { "kod floty", "nr seryjny", "kod stacji zrodlowej", "kod stacji docelowej", "status" };
        }
        public override void Sort()
        {
            if (SortField == "kod floty")
                List = new ObservableCollection<TransferyRowerowForAllView>(List.OrderBy(item => item.KodFloty));
            if (SortField == "nr seryjny")
                List = new ObservableCollection<TransferyRowerowForAllView>(List.OrderBy(item => item.NumerSeryjny));
            if (SortField == "kod stacji zrodlowej")
                List = new ObservableCollection<TransferyRowerowForAllView>(List.OrderBy(item => item.KodStacjiZrodlowej));
            if (SortField == "kod stacji docelowej")
                List = new ObservableCollection<TransferyRowerowForAllView>(List.OrderBy(item => item.KodStacjiDocelowej));
            if (SortField == "data start")
                List = new ObservableCollection<TransferyRowerowForAllView>(List.OrderBy(item => item.DataStartUtc));
            if (SortField == "data koniec")
                List = new ObservableCollection<TransferyRowerowForAllView>(List.OrderBy(item => item.DataKoniecUtc));
            if (SortField == "status")
                List = new ObservableCollection<TransferyRowerowForAllView>(List.OrderBy(item => item.Status));
        }
        public override void Find()
        {
            try
            {
                if (FindField == "kod floty")
                    List = new ObservableCollection<TransferyRowerowForAllView>(List.Where(item => item.KodFloty != null && item.KodFloty.StartsWith(FindTextBox)));
                if (FindField == "nr seryjny")
                    List = new ObservableCollection<TransferyRowerowForAllView>(List.Where(item => item.NumerSeryjny != null && item.NumerSeryjny.StartsWith(FindTextBox)));
                if (FindField == "kod stacji zrodlowej")
                    List = new ObservableCollection<TransferyRowerowForAllView>(List.Where(item => item.KodStacjiZrodlowej != null && item.KodStacjiZrodlowej.StartsWith(FindTextBox)));
                if (FindField == "kod stacji docelowej")
                    List = new ObservableCollection<TransferyRowerowForAllView>(List.Where(item => item.KodStacjiDocelowej != null && item.KodStacjiDocelowej.StartsWith(FindTextBox)));
                if (FindField == "status")
                    List = new ObservableCollection<TransferyRowerowForAllView>(List.Where(item => item.Status != null && item.Status.StartsWith(FindTextBox)));
            }
            catch (Exception e)
            {
                ShowMessageBox("Wpisz wartość do okienka");
            }
        }
        #endregion
    }
}
