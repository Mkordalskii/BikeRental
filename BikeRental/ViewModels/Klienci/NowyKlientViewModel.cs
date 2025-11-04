using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;

namespace BikeRental.ViewModels
{
    public class NowyKlientViewModel : JedenViewModel<Klient>
    {
        #region Constructor 
        public NowyKlientViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj klienta";
            item = new Klient();
            DostepneTypy = new List<string> { "Osoba prywatna", "Firma" };
            WybranyTyp = DostepneTypy[0];
        }
        #endregion
        #region Properties
        //dla kazdego pola ktore bedziemy dodawac dodajemy properties
        public byte Typ // 0 - osoba prywatna, 1 - firma
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
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                if (item.NIP != value)
                {
                    item.NIP = value;
                    OnPropertyChanged(() => NIP);
                }
            }
        }

        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                if (item.Email != value)
                {
                    item.Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    OnPropertyChanged(() => Telefon);
                }
            }
        }
        public DateTime? DataUrodzenia
        {
            get
            {
                return item.DataUrodzenia;
            }
            set
            {
                if (item.DataUrodzenia != value)
                {
                    item.DataUrodzenia = value;
                    OnPropertyChanged(() => DataUrodzenia);
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
            db.Klient.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
        #region ComboBoxList
        public List<string> DostepneTypy { get; }

        private string _wybranyTyp;
        public string WybranyTyp
        {
            get
            {
                return _wybranyTyp;
            }
            set
            {
                if (_wybranyTyp != value)
                {
                    _wybranyTyp = value;
                    OnPropertyChanged(() => WybranyTyp);

                    // mapowanie tekstu na byte do bazy
                    if (value == "Osoba prywatna")
                        Typ = 0;
                    else if (value == "Firma")
                        Typ = 1;
                }
            }
        }
        #endregion
    }
}
