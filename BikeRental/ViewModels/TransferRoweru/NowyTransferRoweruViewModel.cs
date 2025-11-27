using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NowyTransferRoweruViewModel : JedenViewModel<TransferRoweru>
    {
        #region Constructor 
        public NowyTransferRoweruViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj transfer";
            item = new TransferRoweru();
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
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 5;
            item.KiedyDodal = DateTime.Now;
            db.TransferRoweru.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
