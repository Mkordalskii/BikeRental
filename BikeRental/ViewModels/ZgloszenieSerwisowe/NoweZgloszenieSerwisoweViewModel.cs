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
    public class NoweZgloszenieSerwisoweViewModel : JedenViewModel<ZgloszenieSerwisowe>
    {
        #region Constructor 
        public NoweZgloszenieSerwisoweViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj serwis";
            item = new ZgloszenieSerwisowe();
            DataZgloszeniaUtc = DateTime.Today;
            Messenger.Default.Register<KlienciForAllView>(this, getWybranyKlient);
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
        private string _NazwiskoKlienta;
        public string NazwiskoKlienta
        {
            get
            {
                return _NazwiskoKlienta;
            }
            set
            {
                if (_NazwiskoKlienta != value)
                {
                    _NazwiskoKlienta = value;
                    OnPropertyChanged(() => NazwiskoKlienta);
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
        private BaseCommand _ShowKlienciCommand;
        public ICommand ShowKlienciCommand
        {
            get
            {
                if (_ShowKlienciCommand == null) _ShowKlienciCommand = new BaseCommand(
                    () => Messenger.Default.Send("KlienciShow")
                    );
                return _ShowKlienciCommand;
            }
        }
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
            db.ZgloszenieSerwisowe.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        private void getWybranyKlient(KlienciForAllView klient)
        {
            ZglaszajacyKlientId = klient.KlientId;
            NazwiskoKlienta = klient.Nazwisko;
        }
        private void getWybranyRower(RoweryForAllView rower)
        {
            RowerId = rower.RowerId;
            KodFloty = rower.KodFloty;
            NrSeryjny = rower.NumerSeryjny;
        }
        #endregion
        #region ComboBox
        public IQueryable<SlownikZgloszeniePriorytet> PriorytetItems
        {
            get
            {
                return
                    (
                        from priorytet in db.SlownikZgloszeniePriorytet
                        select priorytet
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<SlownikZgloszenieStatus> StatusItems
        {
            get
            {
                return
                    (
                        from status in db.SlownikZgloszenieStatus
                        select status
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<Stacja> StacjaDocelowaItems
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
        #endregion
    }
}
