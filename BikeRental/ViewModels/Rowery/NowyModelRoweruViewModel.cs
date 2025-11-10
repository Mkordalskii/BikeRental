using BikeRental.Models;
using BikeRental.ViewModels.Abstract;
using System;

namespace BikeRental.ViewModels
{
    public class NowyModelRoweruViewModel : JedenViewModel<RowerModel>
    {
        #region MyRegion
        public NowyModelRoweruViewModel() : base()
        {
            DisplayName = "Dodaj/edytuj modele";
            item = new RowerModel();
            E_Bike = false;
        }
        #endregion
        #region Properties
        public string Producent
        {
            get
            {
                return item.Producent;
            }
            set
            {
                if (item.Producent != value)
                {
                    item.Producent = value;
                    OnPropertyChanged(() => Producent);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public string Typ
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
        public bool E_Bike
        {
            get
            {
                return item.E_Bike;
            }
            set
            {
                if (item.E_Bike != value)
                {
                    item.E_Bike = value;
                    OnPropertyChanged(() => E_Bike);
                    OnPropertyChanged(() => NotE_Bike);
                }
            }
        }
        public bool NotE_Bike
        {
            get => !E_Bike;
            set
            {
                //ustawiamy Sprawny jako negację value
                E_Bike = !value;
            }
        }
        public decimal? MasaKg
        {
            get
            {
                return item.MasaKg;
            }
            set
            {
                if (item.MasaKg != value)
                {
                    item.MasaKg = value;
                    OnPropertyChanged(() => MasaKg);
                }
            }
        }

        #endregion
        #region Commands

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = 5; ///np. zalogowany użytkownik
            item.KiedyDodal = DateTime.Now;
            db.RowerModel.Add(item);//to jest dodanie roweru do kolekcji rowerow
            db.SaveChanges();//to jest zapisanie danych do bazy danych
        }

        #endregion Commands
    }
}
