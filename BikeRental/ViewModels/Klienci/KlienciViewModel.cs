using BikeRental.Helper;
using BikeRental.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class KlienciViewModel : WorkspaceViewModel
    {
        #region BazaDanych
        //to jest obiekt ktory reprezentuje cala baze danych
        private readonly BikeRentalDbEntities db;
        #endregion
        #region Command
        //komendy podlacza sie pod element widoku (np. przycisk) i ona wywoluje funkcje, czyli pod przycisk podlaczamy komende ktora wywoluje funkcje
        //to jest komenda do ladowania klientow z bazy, ona zostanie podpieta pod przycisk odswiez
        //podkreslnik oznacza ze dane pole bedzie mialo properties
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) _LoadCommand = new BaseCommand(load); //ta komenda wywola metode load ktora jest zdefiniowana nizej
                return _LoadCommand;
            }
        }
        #endregion
        #region Lista
        //tu beda przechowwyani wszyscy klienci
        private ObservableCollection<Klient> _List;
        public ObservableCollection<Klient> List
        {
            get
            {
                if (_List == null) load(); //jesli lista jest pusta to ja ladujemy metoda lad
                return _List;
            }
            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List); //odswieza wyswietlanie listy towarow
                }
            }
        }
        //ta metoda pobierze wszystkich klientow z bazy danych i zapisze je do listy jako ObservableCollection
        private void load()
        {
            List = new ObservableCollection<Klient>
                (
                db.Klient.ToList()// z bazy danych, pobieram wszystkich klientow i zamieniam na liste
                );
        }
        #endregion
        #region Constructor
        public KlienciViewModel()
        {
            base.DisplayName = "Wszyscy klienci";
            db = new BikeRentalDbEntities();
        }
        #endregion
    }
}
