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
    public class NowaRezerwacjaViewModel : JedenViewModel<Rezerwacja>
    {
        #region Constructor 
        public NowaRezerwacjaViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj rezerwacje";
            item = new Rezerwacja();
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
        #region Helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.Rezerwacja.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        private void getWybranyKlient(KlienciForAllView klient)
        {
            KlientId = klient.KlientId;
            ImieKlienta = klient.Imie;
            NazwiskoKlienta = klient.Nazwisko;
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
        #region ComboBox
        public IQueryable<Rower> KodFlotyItems
        {
            get
            {
                return
                    (
                        from rower in db.Rower
                        where rower.CzyAktywny == true
                        select rower
                    ).ToList().AsQueryable();
            }
        }
        #endregion
    }
}
