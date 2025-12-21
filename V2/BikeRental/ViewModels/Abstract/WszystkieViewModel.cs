using BikeRental.Helper;
using BikeRental.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BikeRental.ViewModels.Abstract
{
    //to jest klasa z ktorej beda dziedziczyc wszystkie ViewModel wyswietlajace wszystkie obiekty biznesowe
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel // T to typ przechowywanej kolekcji
    {

        #region BazaDanych
        //to jest obiekt ktory reprezentuje cala baze danych
        protected readonly BikeRentalDbEntities db;
        #endregion
        #region Command
        //komendy podlacza sie pod element widoku (np. przycisk) i ona wywoluje funkcje, czyli pod przycisk podlaczamy komende ktora wywoluje funkcje
        //to jest komenda do ladowania obiektow z bazy, ona zostanie podpieta pod przycisk odswiez
        //podkreslnik oznacza ze dane pole bedzie mialo properties
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) _LoadCommand = new BaseCommand(Load); //ta komenda wywola metode Load ktora jest zdefiniowana nizej
                return _LoadCommand;
            }
        }
        #endregion
        #region Lista
        //tu beda przechowwyani wszyscy klienci
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) Load(); //jesli lista jest pusta to ja ladujemy metoda Load
                return _List;
            }
            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List); //odswieza wyswietlanie listy obiektow
                }
            }
        }
        //ta metoda pobierze wszystkie obiekty z bazy danych i zapisze je do listy jako ObservableCollection
        //poniewaz ladowanie obiektow jest inne dla kazdego typu obiektow dlatego Load jest abstrakcyjna
        public abstract void Load();
        #endregion
        #region Constructor
        public WszystkieViewModel()
        {
            db = new BikeRentalDbEntities();
        }
        #endregion
        #region Sortowanie i Szukanie
        private BaseCommand _SortCommand; //to jest komenda do podpięcia pod przycisk Sortuj
        private BaseCommand _FindCommand; //komenda podpięta pod przycisk szukaj
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null) _SortCommand = new BaseCommand(Sort);
                return _SortCommand;
            }
        }
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null) _FindCommand = new BaseCommand(Find);
                return _FindCommand;
            }
        }
        public string SortField { get; set; } //to jest prop w ktorym bedziemy zapisywac po czym sortowac
        public List<string> SortComboBoxItems //to jest prop do pobierania elementow comboboxa sortuj
        {
            get
            {
                return getComboBoxSortList();
            }
        }
        public string FindField { get; set; } //to jest prop w ktorym bedziemy zapisywac po czym filtrowac
        public List<string> FindComboBoxItems //to jest prop do pobierania elementow comboboxa sortuj
        {
            get
            {
                return getComboBoxFindList();
            }
        }
        public string FindTextBox { get; set; } //to jest prop w ktorym bedziemy zapisywac poczatek wyszukiwanego slowa
        public abstract void Sort(); //tu bedziemy decydowac w klasach jak sortowac konkretne tabele
        public abstract void Find(); //tu bedziemy decydowac w konkretnych tabelach jak wyszukiwac dane
        public abstract List<string> getComboBoxSortList(); // tu w konkretnych klasach dziedziczacych bedziemy decydowac po czym mozna sortowac
        public abstract List<string> getComboBoxFindList(); // tu w konkretnych klasach dziedziczacych bedziemy decydowac po czym mozna filtrowac
        #endregion
    }
}
