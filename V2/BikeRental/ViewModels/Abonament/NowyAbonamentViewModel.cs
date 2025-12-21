using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NowyAbonamentViewModel : JedenViewModel<Abonament>
    {
        #region Constructor 
        public NowyAbonamentViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj abonament";
            item = new Abonament();
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
        public int PlanCenowyId
        {
            get
            {
                return item.PlanCenowyId;
            }
            set
            {
                if (item.PlanCenowyId != value)
                {
                    item.PlanCenowyId = value;
                    OnPropertyChanged(() => PlanCenowyId);
                }
            }
        }
        public DateTime DataStart
        {
            get
            {
                return item.DataStart;
            }
            set
            {
                if (item.DataStart != value)
                {
                    item.DataStart = value;
                    OnPropertyChanged(() => DataStart);
                }
            }
        }
        public DateTime DataKoniec
        {
            get
            {
                return item.DataKoniec;
            }
            set
            {
                if (item.DataKoniec != value)
                {
                    item.DataKoniec = value;
                    OnPropertyChanged(() => DataKoniec);
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
            db.Abonament.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
