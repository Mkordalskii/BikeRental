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
    public class NowaPlatnoscViewModel : JedenViewModel<Platnosc>
    {
        #region Constructor 
        public NowaPlatnoscViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj platnosc";
            item = new Platnosc();
            DataPlatnosci = DateTime.Today;
            Messenger.Default.Register<KlienciForAllView>(this, getWybranyKlient);
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
        public int? WypozyczenieId
        {
            get
            {
                return item.WypozyczenieId;
            }
            set
            {
                if (item.WypozyczenieId != value)
                {
                    item.WypozyczenieId = value;
                    OnPropertyChanged(() => WypozyczenieId);
                }
            }
        }
        public DateTime DataPlatnosci
        {
            get
            {
                return item.DataPlatnosci;
            }
            set
            {
                if (item.DataPlatnosci != value)
                {
                    item.DataPlatnosci = value;
                    OnPropertyChanged(() => DataPlatnosci);
                }
            }
        }
        public decimal Kwota
        {
            get
            {
                return item.Kwota;
            }
            set
            {
                if (item.Kwota != value)
                {
                    item.Kwota = value;
                    OnPropertyChanged(() => Kwota);
                }
            }
        }

        public string Waluta
        {
            get
            {
                return item.Waluta;
            }
            set
            {
                if (item.Waluta != value)
                {
                    item.Waluta = value;
                    OnPropertyChanged(() => Waluta);
                }
            }
        }
        public byte Metoda //0 karta, 1 blik, 2 gotowka, 3 inne
        {
            get
            {
                return item.Metoda;
            }
            set
            {
                if (item.Metoda != value)
                {
                    item.Metoda = value;
                    OnPropertyChanged(() => Metoda);
                }
            }
        }
        public string Referencja
        {
            get
            {
                return item.Referencja;
            }
            set
            {
                if (item.Referencja != value)
                {
                    item.Referencja = value;
                    OnPropertyChanged(() => Referencja);
                }
            }
        }
        public byte Status //0 autoryzacja, 1 zaksiegowana, 2 zwrot, 3 odrzucona
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
        #region helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.Platnosc.Add(item);//to jest dodanie Platnosci do kolekcji
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
        public IQueryable<SlownikPlatnoscMetoda> MetodaItems
        {
            get
            {
                return
                    (
                        from metoda in db.SlownikPlatnoscMetoda
                        select metoda
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<SlownikPlatnoscStatus> StatusItems
        {
            get
            {
                return
                    (
                        from status in db.SlownikPlatnoscStatus
                        select status
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<Wypozyczenie> IdWypozyczeniaItems
        {
            get
            {
                return
                    (
                        from id in db.Wypozyczenie
                        select id
                    ).ToList().AsQueryable();
            }
        }
        #endregion
    }
}
