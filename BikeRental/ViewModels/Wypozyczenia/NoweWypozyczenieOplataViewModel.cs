using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

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
        #region Commands
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.WypozyczenieOplata.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
