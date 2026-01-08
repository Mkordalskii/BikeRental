using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace BikeRental.ViewModels
{
    public class NoweWypozyczenieOplataViewModel : JedenViewModel<WypozyczenieOplata>
    {
        #region Constructor 
        public NoweWypozyczenieOplataViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj oplate";
            item = new WypozyczenieOplata();
        }
        #endregion
        #region Properties
        public int WypozyczenieId
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
        public byte Typ //0 start, 1 czas, 2 doplata, 3 strefa, 4 kara
        {
            get
            {
                return item.Typ;
            }
            set
            {
                if (item.Typ != value)
                {
                    item.Typ = value;
                    OnPropertyChanged(() => Typ);
                }
            }
        }
        public int? IloscMin
        {
            get
            {
                return item.IloscMin;
            }
            set
            {
                if (item.IloscMin != value)
                {
                    item.IloscMin = value;
                    OnPropertyChanged(() => IloscMin);
                }
            }
        }
        public decimal? Stawka
        {
            get
            {
                return item.Stawka;
            }
            set
            {
                if (item.Stawka != value)
                {
                    item.Stawka = value;
                    OnPropertyChanged(() => Stawka);
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
        #endregion
        #region Helpers
        public override void Save()
        {
            Keyboard.ClearFocus(); // aby wartość liczbowa z ostatniego okienka automatycznie straciła focus przy zapisywaniu i została wysłana
            Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.WypozyczenieOplata.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
        #region ComboBox
        public IQueryable<Wypozyczenie> WypozyczenieItems
        {
            get
            {
                return
                    (
                        from wypozyczenie in db.Wypozyczenie
                        where wypozyczenie.CzyAktywny == true
                        select wypozyczenie
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<SlownikWypozyczenieOplataTyp> TypItems
        {
            get
            {
                return
                    (
                        from typ in db.SlownikWypozyczenieOplataTyp
                        select typ
                    ).ToList().AsQueryable();
            }
        }
        #endregion
    }
}
