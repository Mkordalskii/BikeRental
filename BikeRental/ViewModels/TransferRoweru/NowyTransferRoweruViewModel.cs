using BikeRental.Helper;
using BikeRental.Models;
using BikeRental.Models.EntitiesForView;
using BikeRental.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class NowyTransferRoweruViewModel : JedenViewModel<TransferRoweru>
    {
        #region Constructor 
        public NowyTransferRoweruViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj transfer";
            item = new TransferRoweru();
            Messenger.Default.Register<RoweryForAllView>(this, getWybranyRower);
        }
        #endregion
        #region Properties
        public int RowerId
        {
            get
            {
                return item.RowerId;
            }
            set
            {
                if (item.RowerId != value)
                {
                    item.RowerId = value;
                    OnPropertyChanged(() => RowerId);
                }
            }
        }
        private string _KodFloty;
        public string KodFloty
        {
            get
            {
                return _KodFloty;
            }
            set
            {
                if (_KodFloty != value)
                {
                    _KodFloty = value;
                    OnPropertyChanged(() => KodFloty);
                }
            }
        }
        private string _NrSeryjny;
        public string NrSeryjny
        {
            get
            {
                return _NrSeryjny;
            }
            set
            {
                if (_NrSeryjny != value)
                {
                    _NrSeryjny = value;
                    OnPropertyChanged(() => NrSeryjny);
                }
            }
        }
        public int StacjaZrodlowaId
        {
            get
            {
                return item.StacjaZrodlowaId;
            }
            set
            {
                if (item.StacjaZrodlowaId != value)
                {
                    item.StacjaZrodlowaId = value;
                    OnPropertyChanged(() => StacjaZrodlowaId);
                }
            }
        }
        public int StacjaDocelowaId
        {
            get
            {
                return item.StacjaDocelowaId;
            }
            set
            {
                if (item.StacjaDocelowaId != value)
                {
                    item.StacjaDocelowaId = value;
                    OnPropertyChanged(() => StacjaDocelowaId);
                }
            }
        }
        public DateTime DataStartUtc
        {
            get
            {
                return item.DataStartUtc;
            }
            set
            {
                if (item.DataStartUtc != value)
                {
                    item.DataStartUtc = value;
                    OnPropertyChanged(() => DataStartUtc);
                }
            }
        }
        public DateTime? DataKoniecUtc
        {
            get
            {
                return item.DataKoniecUtc;
            }
            set
            {
                if (item.DataKoniecUtc != value)
                {
                    item.DataKoniecUtc = value;
                    OnPropertyChanged(() => DataKoniecUtc);
                }
            }
        }
        public byte Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                if (item.Status != value)
                {
                    item.Status = value;
                    OnPropertyChanged(() => Status);
                }
            }
        }
        public string Uwagi
        {
            get
            {
                return item.Uwagi;
            }
            set
            {
                if (item.Uwagi != value)
                {
                    item.Uwagi = value;
                    OnPropertyChanged(() => Uwagi);
                }
            }
        }

        #endregion
        #region Commands
        private BaseCommand _ShowRoweryCommand;
        public ICommand ShowRoweryCommand
        {
            get
            {
                if (_ShowRoweryCommand == null) _ShowRoweryCommand = new BaseCommand(
                    () => Messenger.Default.Send("RoweryShow")
                    );
                return _ShowRoweryCommand;
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.TransferRoweru.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        private void getWybranyRower(RoweryForAllView rower)
        {
            RowerId = rower.RowerId;
            KodFloty = rower.KodFloty;
            NrSeryjny = rower.NumerSeryjny;
        }
        #endregion
        #region ComboBox
        public IQueryable<Stacja> StacjaItems
        {
            get
            {
                return
                    (
                        from stacja in db.Stacja
                        where stacja.CzyAktywny == true
                        select stacja
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<SlownikTransferStatus> StatusItems
        {
            get
            {
                return
                    (
                        from status in db.SlownikTransferStatus
                        select status
                    ).ToList().AsQueryable();
            }
        }
        #endregion
    }
}
