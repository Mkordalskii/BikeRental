using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
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
            return new List<string> { "cena", "kod", "nazwa" };
        }
        public override List<string> getComboBoxFindList()
        {
            return null;
        }
        public override void Sort()
        { }
        public override void Find()
        {

        }
        #endregion
    }
}
