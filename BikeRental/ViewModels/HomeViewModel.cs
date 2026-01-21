using BikeRental.Helper;
using BikeRental.Models;
using BikeRental.Models.BusinessLogic;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class HomeViewModel : WorkspaceViewModel
    {
        #region Baza danych
        private readonly BikeRentalDbEntities db;
        #endregion
        #region Konstruktor
        public HomeViewModel()
        {
            db = new BikeRentalDbEntities();
            this.DisplayName = "Strona główna";
            _homePageB = new HomePageB(db);
            AktywneWypozyczenia = _homePageB.GetActiveRentalsCount();
            DostepneRowery = _homePageB.GetAvilableBikesCount();
            ZarezerwowaneRowery = _homePageB.GetReservedBikesCount();
            LacznePrzychody = _homePageB.GetTotalRevenue();
        }
        #endregion
        #region Pola i wlasciwosci
        private HomePageB _homePageB;
        private int _AktywneWypozyczenia;
        private int _DostepneRowery;
        private int _ZarezerwowaneRowery;
        private decimal _LacznePrzychody;
        public int AktywneWypozyczenia
        {
            get
            {
                return _AktywneWypozyczenia;
            }
            set
            {
                _AktywneWypozyczenia = value;
                OnPropertyChanged(() => AktywneWypozyczenia);
            }
        }
        public int DostepneRowery
        {
            get
            {
                return _DostepneRowery;
            }
            set
            {
                _DostepneRowery = value;
                OnPropertyChanged(() => DostepneRowery);
            }
        }
        public int ZarezerwowaneRowery
        {
            get
            {
                return _ZarezerwowaneRowery;
            }
            set
            {
                _ZarezerwowaneRowery = value;
                OnPropertyChanged(() => ZarezerwowaneRowery);
            }
        }
        public decimal LacznePrzychody
        {
            get
            {
                return _LacznePrzychody;
            }
            set
            {
                _LacznePrzychody = value;
                OnPropertyChanged(() => LacznePrzychody);
            }
        }
        #endregion
        #region Commands
        private BaseCommand _AddAktywneWypozyczeniaCommand;
        private BaseCommand _AddRezerwacjaCommand;
        private BaseCommand _AddKlientCommand;
        public ICommand AddAktywneWypozyczeniaCommand
        {
            get
            {
                if (_AddAktywneWypozyczeniaCommand == null) _AddAktywneWypozyczeniaCommand = new BaseCommand(AddAktywneWypozyczenia); //ta komenda wywola metode Add ktora jest zdefiniowana nizej
                return _AddAktywneWypozyczeniaCommand;
            }
        }
        public ICommand AddRezerwacjaCommand
        {
            get
            {
                if (_AddRezerwacjaCommand == null) _AddRezerwacjaCommand = new BaseCommand(AddRezerwacja);
                return _AddRezerwacjaCommand;
            }
        }
        public ICommand AddKlientCommand
        {
            get
            {
                if (_AddKlientCommand == null) _AddKlientCommand = new BaseCommand(AddKlient);
                return _AddKlientCommand;
            }
        }
        #endregion
        #region helpers
        private void AddAktywneWypozyczenia()
        {
            //ten Messenger jest z CommunityToolkit, wysyla komunikat do MainWindowViewModel
            Messenger.Default.Send("Wszystkie aktywne wypozyczeniaAdd");
        }
        private void AddRezerwacja()
        {
            Messenger.Default.Send("Wszystkie rezerwacjeAdd");
        }
        private void AddKlient()
        {
            Messenger.Default.Send("Wszyscy klienciAdd");
        }
        #endregion

    }
}
