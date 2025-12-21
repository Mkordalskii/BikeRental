using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NoweWypozyczenieViewModel : JedenViewModel<Wypozyczenie>
    {
        #region Constructor 
        public NoweWypozyczenieViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj wypozyczenie";
            item = new Wypozyczenie();
        }
        #endregion
        #region Properties
        //dla kazdego pola ktore bedziemy dodawac dodajemy properties
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
        public DateTime StartUtc
        {
            get
            {
                return item.StartUtc;
            }
            set
            {
                if (item.StartUtc != value)
                {
                    item.StartUtc = value;
                    OnPropertyChanged(() => StartUtc);
                }
            }
        }
        public DateTime KoniecUtc
        {
            get
            {
                return item.KoniecUtc;
            }
            set
            {
                if (item.KoniecUtc != value)
                {
                    item.KoniecUtc = value;
                    OnPropertyChanged(() => KoniecUtc);
                }
            }
        }

        public int? StartStacjaId
        {
            get
            {
                return item.StartStacjaId;
            }
            set
            {
                if (item.StartStacjaId != value)
                {
                    item.StartStacjaId = value;
                    OnPropertyChanged(() => StartStacjaId);
                }
            }
        }
        public int? KoniecStacjaId
        {
            get
            {
                return item.KoniecStacjaId;
            }
            set
            {
                if (item.KoniecStacjaId != value)
                {
                    item.KoniecStacjaId = value;
                    OnPropertyChanged(() => KoniecStacjaId);
                }
            }
        }
        public decimal? StartSzerGeo
        {
            get
            {
                return item.StartSzerGeo;
            }
            set
            {
                if (item.StartSzerGeo != value)
                {
                    item.StartSzerGeo = value;
                    OnPropertyChanged(() => StartSzerGeo);
                }
            }
        }
        public decimal? StartDlugGeo
        {
            get
            {
                return item.StartDlugGeo;
            }
            set
            {
                if (item.StartDlugGeo != value)
                {
                    item.StartDlugGeo = value;
                    OnPropertyChanged(() => StartDlugGeo);
                }
            }
        }
        public decimal? KoniecSzerGeo
        {
            get
            {
                return item.KoniecSzerGeo;
            }
            set
            {
                if (item.KoniecSzerGeo != value)
                {
                    item.KoniecSzerGeo = value;
                    OnPropertyChanged(() => KoniecSzerGeo);
                }
            }
        }
        public decimal? KoniecDlugGeo
        {
            get
            {
                return item.KoniecDlugGeo;
            }
            set
            {
                if (item.KoniecDlugGeo != value)
                {
                    item.KoniecDlugGeo = value;
                    OnPropertyChanged(() => KoniecDlugGeo);
                }
            }
        }
        public decimal? OdlegloscKm
        {
            get
            {
                return item.OdlegloscKm;
            }
            set
            {
                if (item.OdlegloscKm != value)
                {
                    item.OdlegloscKm = value;
                    OnPropertyChanged(() => OdlegloscKm);
                }
            }
        }
        public int PlanCenowyIdSnapshot
        {
            get
            {
                return item.PlanCenowyIdSnapshot;
            }
            set
            {
                if (item.PlanCenowyIdSnapshot != value)
                {
                    item.PlanCenowyIdSnapshot = value;
                    OnPropertyChanged(() => PlanCenowyIdSnapshot);
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
            db.Wypozyczenie.Add(item);//to jest dodanie wypozyczenia do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
