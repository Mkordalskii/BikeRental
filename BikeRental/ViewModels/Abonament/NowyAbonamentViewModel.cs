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
    public class NowyAbonamentViewModel : JedenViewModel<Abonament>
    {
        #region Constructor 
        public NowyAbonamentViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj abonament";
            item = new Abonament();
            DataStart = DateTime.Today;
            DataKoniec = DateTime.Today;
            Messenger.Default.Register<KlienciForAllView>(this, getWybranyKlient);
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
        private string _ImieKlienta;
        public string ImieKlienta
        {
            get
            {
                return _ImieKlienta;
            }
            set
            {
                if (_ImieKlienta != value)
                {
                    _ImieKlienta = value;
                    OnPropertyChanged(() => ImieKlienta);
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
        public IQueryable<SlownikAbonamentStatus> StatusItems
        {
            get
            {
                return
                    (
                        from status in db.SlownikAbonamentStatus
                        select status
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<PlanCenowy> PlanCenowyItems
        {
            get
            {
                return
                    (
                        from planCenowy in db.PlanCenowy
                        where planCenowy.CzyAktywny == true
                        select planCenowy
                    ).ToList().AsQueryable();
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
        #endregion
        #region helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.Abonament.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        private void getWybranyKlient(KlienciForAllView klient)
        {
            KlientId = klient.KlientId;
            ImieKlienta = klient.Imie;
            NazwiskoKlienta = klient.Nazwisko;
        }
        #endregion
    }
}
