using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NowaRezerwacjaViewModel : JedenViewModel<Rezerwacja>
    {
        #region Constructor 
        public NowaRezerwacjaViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj rezerwacje";
            item = new Rezerwacja();
        }
        #endregion
        #region Properties
        public int KlientId
        {
            get
            {
                return item.KlientId;
            }
            set
            {
                if (item.KlientId != value)
                {
                    item.KlientId = value;
                    OnPropertyChanged(() => KlientId);
                }
            }
        }
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
        public DateTime DataOdUtc
        {
            get
            {
                return item.DataOdUtc;
            }
            set
            {
                if (item.DataOdUtc != value)
                {
                    item.DataOdUtc = value;
                    OnPropertyChanged(() => DataOdUtc);
                }
            }
        }
        public DateTime DataDoUtc
        {
            get
            {
                return item.DataDoUtc;
            }
            set
            {
                if (item.DataDoUtc != value)
                {
                    item.DataDoUtc = value;
                    OnPropertyChanged(() => DataDoUtc);
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

        #endregion
        #region Commands
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.Rezerwacja.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
