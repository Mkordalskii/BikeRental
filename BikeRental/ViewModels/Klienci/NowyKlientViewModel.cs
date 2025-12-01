using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeRental.ViewModels
{
    public class NowyKlientViewModel : JedenViewModel<Klient>
    {
        #region Constructor 
        public NowyKlientViewModel() : base()
        {
            base.DisplayName = "Dodaj/Edytuj klienta";
            item = new Klient();
            DostepneTypy = db.SlownikKlientTyp
                .OrderBy(t => t.Kolejnosc)
                .ToList();
            Typ = (byte)DostepneTypy[0].TypId; // ustawienie domyslnego typu
        }
        #endregion
        #region Properties
        //dla kazdego pola ktore bedziemy dodawac dodajemy properties
        public byte Typ // FK do SlownikKlientTyp.TypId
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
            item.KtoDodal = /* np. zalogowany użytkownik */ 1;
            item.KiedyDodal = DateTime.Now;
            db.Klient.Add(item);//to jest dodanie towaru do kolekcji towarow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }
        #endregion
        #region ComboBoxList
        public List<SlownikKlientTyp> DostepneTypy { get; }
        #endregion
    }
}
