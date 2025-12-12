using BikeRental.Helper;
using BikeRental.Models;
using BikeRental.Models.BusinessLogic;
using BikeRental.Models.EntitiesForView;
using System;
using System.Linq;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class RaportWypozyczenViewModel : WorkspaceViewModel
    {
        #region Baza danych
        private readonly BikeRentalDbEntities db;
        #endregion
        #region Konstruktor
        public RaportWypozyczenViewModel()
        {
            DisplayName = "Raport wypozyczen";
            db = new BikeRentalDbEntities();
            _Raport = new RaportWypozyczenB(db);
            DataDo = DateTime.Today;
            DataOd = DateTime.Today.AddDays(-30);
            Wynik = new RaportWypozyczenPodsumowanieB();
        }
        #endregion
        #region Pola i wlasciwosci
        private DateTime _DataOd;
        private DateTime _DataDo;
        private int? _IdKlienta;
        private int? _IdStacjaStart;
        private int? _IdStacjaKoniec;
        private int? _IdRoweru;
        private RaportWypozyczenB _Raport;

        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        public int? IdKlienta
        {
            get
            {
                return _IdKlienta;
            }
            set
            {
                if (_IdKlienta != value)
                {
                    _IdKlienta = value;
                    OnPropertyChanged(() => IdKlienta);
                }
            }
        }
        public int? IdStacjaStart
        {
            get
            {
                return _IdStacjaStart;
            }
            set
            {
                if (_IdStacjaStart != value)
                {
                    _IdStacjaStart = value;
                    OnPropertyChanged(() => IdStacjaStart);
                }
            }
        }
        public int? IdStacjaKoniec
        {
            get
            {
                return _IdStacjaKoniec;
            }
            set
            {
                if (_IdStacjaKoniec != value)
                {
                    _IdStacjaKoniec = value;
                    OnPropertyChanged(() => IdStacjaKoniec);
                }
            }
        }
        public int? IdRoweru
        {
            get
            {
                return _IdRoweru;
            }
            set
            {
                if (_IdRoweru != value)
                {
                    _IdRoweru = value;
                    OnPropertyChanged(() => IdRoweru);
                }
            }
        }
        public RaportWypozyczenB Raport
        {
            get
            {
                return _Raport;
            }
            set
            {
                if (_Raport != value)
                {
                    _Raport = value;
                    OnPropertyChanged(() => Raport);
                }
            }
        }
        private RaportWypozyczenPodsumowanieB _wynik;
        public RaportWypozyczenPodsumowanieB Wynik
        {
            get => _wynik;
            set
            {
                _wynik = value;
                OnPropertyChanged(() => Wynik);
            }
        }
        public IQueryable<KeyAndValue> KlienciComboBoxItems
        {
            get
            {
                return new RaportWypozyczenB(db).GetKlienciCollection();
            }
        }
        public IQueryable<KeyAndValue> StacjeComboBoxItems
        {
            get
            {
                return new RaportWypozyczenB(db).GetStacjeCollection();
            }
        }
        public IQueryable<KeyAndValue> RoweryComboBoxItems
        {
            get
            {
                return new RaportWypozyczenB(db).GetRoweryCollection();
            }
        }
        #endregion
        #region Komendy
        private BaseCommand _GenerujRaport;
        private BaseCommand _Wyczysc;
        public ICommand GenerujRaport
        {
            get
            {
                if (_GenerujRaport == null)
                    _GenerujRaport = new BaseCommand(generujRaportClick);
                return _GenerujRaport;
            }
        }
        public ICommand Wyczysc
        {
            get
            {
                if (_Wyczysc == null)
                    _Wyczysc = new BaseCommand(wyczyscClick);
                return _Wyczysc;
            }
        }
        private void wyczyscClick()
        {
            //domysle daty
            //DataOd = DateTime.Today.AddDays(-30);
            //DataDo = DateTime.Today;

            //filtry (ComboBoxy)
            IdKlienta = null;
            IdRoweru = null;
            IdStacjaStart = null;
            IdStacjaKoniec = null;

            //wynik raportu
            Wynik = new RaportWypozyczenPodsumowanieB
            {
                LiczbaWypozyczen = null,
                LacznyCzasMin = null,
                LacznyDystansKm = null,
                Przychod = null
            };
        }
        private void generujRaportClick()
        {
            //to jest wywolanie funkcji z klasy logiki biznesowej
            Wynik = _Raport.GenerujPodsumowanie(
                DataOd,
                DataDo,
                IdKlienta,
                IdRoweru,
                IdStacjaStart,
                IdStacjaKoniec);
        }
        #endregion
    }
}
