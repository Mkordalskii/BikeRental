using BikeRental.Models;
using BikeRental.Models.BusinessLogic;

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

    }
}
