using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NowaPlatnoscViewModel : JedenViewModel<Platnosc>
    {
        #region Constructor 
        public NowaPlatnoscViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj platnosc";
            item = new Platnosc();
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
        #region Commands
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = /* np. zalogowany użytkownik */ 5;
            item.KiedyDodal = DateTime.Now;
            db.Platnosc.Add(item);//to jest dodanie Platnosci do kolekcji
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
    }
}
