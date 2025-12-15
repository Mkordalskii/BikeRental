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
            DisplayName = "Raport wypożyczeń";
            db = new BikeRentalDbEntities();

            DataOd = DateTime.Today.AddDays(-30);
            DataDo = DateTime.Today;

            WyczyscWynik();
        }
        #endregion

        #region Pola i właściwości (filtry)
        private DateTime _DataOd;
        private DateTime _DataDo;
        private int? _IdKlienta;
        private int? _IdRoweru;
        private int? _IdStacjaStart;
        private int? _IdStacjaKoniec;

        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                _DataOd = value;
                OnPropertyChanged(() => DataOd);
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
                _DataDo = value;
                OnPropertyChanged(() => DataDo);
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
                _IdKlienta = value;
                OnPropertyChanged(() => IdKlienta);
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
                _IdRoweru = value;
                OnPropertyChanged(() => IdRoweru);
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
                _IdStacjaStart = value;
                OnPropertyChanged(() => IdStacjaStart);
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
                _IdStacjaKoniec = value;
                OnPropertyChanged(() => IdStacjaKoniec);
            }
        }
        #endregion

        #region Wyniki
        private int? _LiczbaWypozyczen;
        private int? _LacznyCzasMin;
        private decimal? _LacznyDystansKm;
        private decimal? _Przychod;

        public int? LiczbaWypozyczen
        {
            get
            {
                return
                    _LiczbaWypozyczen;
            }
            set
            {
                _LiczbaWypozyczen = value;
                OnPropertyChanged(() => LiczbaWypozyczen);
            }
        }

        public int? LacznyCzasMin
        {
            get
            {
                return _LacznyCzasMin;
            }
            set
            {
                _LacznyCzasMin = value;
                OnPropertyChanged(() => LacznyCzasMin);
            }
        }

        public decimal? LacznyDystansKm
        {
            get
            {
                return _LacznyDystansKm;
            }
            set
            {
                _LacznyDystansKm = value;
                OnPropertyChanged(() => LacznyDystansKm);
            }
        }

        public decimal? Przychod
        {
            get
            {
                return _Przychod;
            }
            set
            {
                _Przychod = value;
                OnPropertyChanged(() => Przychod);
            }
        }
        #endregion

        #region ComboBox Items
        public IQueryable<KeyAndValue> KlienciComboBoxItems
        {
            get { return new KlientB(db).GetKlienciKeyAndValueItems(); }
        }

        public IQueryable<KeyAndValue> StacjeComboBoxItems
        {
            get { return new StacjaB(db).GetStacjeKeyAndValueItems(); }
        }

        public IQueryable<KeyAndValue> RoweryComboBoxItems
        {
            get { return new RowerB(db).GetRoweryKeyAndValueItems(); }
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

        private void generujRaportClick()
        {
            RaportWypozyczenPodsumowanieB b = new RaportWypozyczenPodsumowanieB(db);

            LiczbaWypozyczen = b.LiczbaWypozyczenOkres(DataOd, DataDo, IdKlienta, IdRoweru, IdStacjaStart, IdStacjaKoniec);
            LacznyCzasMin = b.LacznyCzasMinOkres(DataOd, DataDo, IdKlienta, IdRoweru, IdStacjaStart, IdStacjaKoniec);
            LacznyDystansKm = b.LacznyDystansKmOkres(DataOd, DataDo, IdKlienta, IdRoweru, IdStacjaStart, IdStacjaKoniec);
            Przychod = b.PrzychodOkres(DataOd, DataDo, IdKlienta, IdRoweru, IdStacjaStart, IdStacjaKoniec);
        }

        private void wyczyscClick()
        {
            IdKlienta = null;
            IdRoweru = null;
            IdStacjaStart = null;
            IdStacjaKoniec = null;
            WyczyscWynik();
        }

        private void WyczyscWynik()
        {
            LiczbaWypozyczen = null;
            LacznyCzasMin = null;
            LacznyDystansKm = null;
            Przychod = null;
        }
        #endregion
    }
}
