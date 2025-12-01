using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NoweZgloszenieSerwisoweViewModel : JedenViewModel<ZgloszenieSerwisowe>
    {
        #region Constructor 
        public NoweZgloszenieSerwisoweViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj serwis";
            item = new ZgloszenieSerwisowe();
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
        public int? ZglaszajacyKlientId
        {
            get
            {
                return item.ZglaszajacyKlientId;
            }
            set
            {
                if (item.ZglaszajacyKlientId != value)
                {
                    item.ZglaszajacyKlientId = value;
                    OnPropertyChanged(() => ZglaszajacyKlientId);
                }
            }
        }
        public DateTime DataZgloszeniaUtc
        {
            get
            {
                return item.DataZgloszeniaUtc;
            }
            set
            {
                if (item.DataZgloszeniaUtc != value)
                {
                    item.DataZgloszeniaUtc = value;
                    OnPropertyChanged(() => DataZgloszeniaUtc);
                }
            }
        }
        public byte Priorytet
        {
            get
            {
                return item.Priorytet;
            }
            set
            {
                if (item.Priorytet != value)
                {
                    item.Priorytet = value;
                    OnPropertyChanged(() => Priorytet);
                }
            }
        }
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
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
        public int? StacjaDocelowaId
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

        #endregion
        #region Commands
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.ZgloszenieSerwisowe.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
